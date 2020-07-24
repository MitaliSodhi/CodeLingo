import os
import random

from redis.client import StrictRedis
from redis.connection import ConnectionPool, Connection
from redis.exceptions import ConnectionError, ResponseError
from redis._compat import xrange, nativestr


class MainNotFoundError(ConnectionError):
    pass


class SubordinateNotFoundError(ConnectionError):
    pass


class SentinelManagedConnection(Connection):
    def __init__(self, **kwargs):
        self.connection_pool = kwargs.pop('connection_pool')
        super(SentinelManagedConnection, self).__init__(**kwargs)

    def connect_to(self, address):
        self.host, self.port = address
        super(SentinelManagedConnection, self).connect()
        if self.connection_pool.check_connection:
            self.send_command('PING')
            if nativestr(self.read_response()) != 'PONG':
                raise ConnectionError('PING failed')

    def connect(self):
        if self._sock:
            return  # already connected
        if self.connection_pool.is_main:
            self.connect_to(self.connection_pool.get_main_address())
        else:
            for subordinate in self.connection_pool.rotate_subordinates():
                try:
                    return self.connect_to(subordinate)
                except ConnectionError:
                    continue
            raise SubordinateNotFoundError  # Never be here


class SentinelConnectionPool(ConnectionPool):
    """
    Sentinel backed connection pool.

    If ``check_connection`` flag is set to True, SentinelManagedConnection
    sends a PING command right after establishing the connection.
    """

    def __init__(self, service_name, sentinel_manager, **kwargs):
        kwargs['connection_class'] = kwargs.get(
            'connection_class', SentinelManagedConnection)
        self.is_main = kwargs.pop('is_main', True)
        self.check_connection = kwargs.pop('check_connection', False)
        super(SentinelConnectionPool, self).__init__(**kwargs)
        self.connection_kwargs['connection_pool'] = self
        self.service_name = service_name
        self.sentinel_manager = sentinel_manager
        self.main_address = None
        self.subordinate_rr_counter = None

    def get_main_address(self):
        main_address = self.sentinel_manager.discover_main(
            self.service_name)
        if not self.is_main:
            pass
        elif self.main_address is None:
            self.main_address = main_address
        elif main_address != self.main_address:
            self.disconnect()  # Main address changed
        return main_address

    def rotate_subordinates(self):
        "Round-robin subordinate balancer"
        subordinates = self.sentinel_manager.discover_subordinates(self.service_name)
        if subordinates:
            if self.subordinate_rr_counter is None:
                self.subordinate_rr_counter = random.randint(0, len(subordinates) - 1)
            for _ in xrange(len(subordinates)):
                self.subordinate_rr_counter = (
                    self.subordinate_rr_counter + 1) % len(subordinates)
                subordinate = subordinates[self.subordinate_rr_counter]
                yield subordinate
        # Fallback to the main connection
        try:
            yield self.get_main_address()
        except MainNotFoundError:
            pass
        raise SubordinateNotFoundError('No subordinate found for %r' % (self.service_name))

    def _checkpid(self):
        if self.pid != os.getpid():
            self.disconnect()
            self.__init__(self.service_name, self.sentinel_manager,
                          connection_class=self.connection_class,
                          max_connections=self.max_connections,
                          **self.connection_kwargs)


class Sentinel(object):
    """
    Redis Sentinel cluster client

    >>> from redis.sentinel import Sentinel
    >>> sentinel = Sentinel([('localhost', 26379)], socket_timeout=0.1)
    >>> main = sentinel.main_for('mymain', socket_timeout=0.1)
    >>> main.set('foo', 'bar')
    >>> subordinate = sentinel.subordinate_for('mymain', socket_timeout=0.1)
    >>> subordinate.get('foo')
    'bar'

    ``sentinels`` is a list of sentinel nodes. Each node is represented by
    a pair (hostname, port).

    Use ``socket_timeout`` to specify a timeout for sentinel clients.
    It's recommended to use short timeouts.

    Use ``min_other_sentinels`` to filter out sentinels with not enough peers.
    """

    def __init__(self, sentinels, password=None, socket_timeout=None,
                 min_other_sentinels=0):
        self.sentinels = [StrictRedis(hostname, port, password=password,
                                      socket_timeout=socket_timeout)
                          for hostname, port in sentinels]
        self.min_other_sentinels = min_other_sentinels

    def check_main_state(self, state, service_name):
        if not state['is_main'] or state['is_sdown'] or state['is_odown']:
            return False
        # Check if our sentinel doesn't see other nodes
        if state['num-other-sentinels'] < self.min_other_sentinels:
            return False
        return True

    def discover_main(self, service_name):
        """
        Asks sentinel servers for the Redis main's address corresponding
        to the service labeled ``service_name``.

        Returns a pair (address, port) or raises MainNotFoundError if no
        main is found.
        """
        for sentinel_no, sentinel in enumerate(self.sentinels):
            try:
                mains = sentinel.sentinel_mains()
            except ConnectionError:
                continue
            state = mains.get(service_name)
            if state and self.check_main_state(state, service_name):
                # Put this sentinel at the top of the list
                self.sentinels[0], self.sentinels[sentinel_no] = (
                    sentinel, self.sentinels[0])
                return state['ip'], state['port']
        raise MainNotFoundError("No main found for %r" % (service_name,))

    def filter_subordinates(self, subordinates):
        "Remove subordinates that are in an ODOWN or SDOWN state"
        subordinates_alive = []
        for subordinate in subordinates:
            if subordinate['is_odown'] or subordinate['is_sdown']:
                continue
            subordinates_alive.append((subordinate['ip'], subordinate['port']))
        return subordinates_alive

    def discover_subordinates(self, service_name):
        "Returns a list of alive subordinates for service ``service_name``"
        for sentinel in self.sentinels:
            try:
                subordinates = sentinel.sentinel_subordinates(service_name)
            except (ConnectionError, ResponseError):
                continue
            subordinates = self.filter_subordinates(subordinates)
            if subordinates:
                return subordinates
        return []

    def main_for(self, service_name, redis_class=StrictRedis,
                   connection_pool_class=SentinelConnectionPool, **kwargs):
        """
        Returns a redis client instance for the ``service_name`` main.

        A SentinelConnectionPool class is used to retrive the main's
        address before establishing a new connection.

        NOTE: If the main's address has changed, any cached connections to
        the old main are closed.

        By default clients will be a redis.StrictRedis instance. Specify a
        different class to the ``redis_class`` argument if you desire
        something different.

        The ``connection_pool_class`` specifies the connection pool to use.
        The SentinelConnectionPool will be used by default.

        All other arguments are passed directly to the SentinelConnectionPool.
        """
        kwargs['is_main'] = True
        return redis_class(connection_pool=connection_pool_class(
            service_name, self, **kwargs))

    def subordinate_for(self, service_name, redis_class=StrictRedis,
                  connection_pool_class=SentinelConnectionPool, **kwargs):
        """
        Returns redis client instance for the ``service_name`` subordinate(s).

        A SentinelConnectionPool class is used to retrive the subordinate's
        address before establishing a new connection.

        By default clients will be a redis.StrictRedis instance. Specify a
        different class to the ``redis_class`` argument if you desire
        something different.

        The ``connection_pool_class`` specifies the connection pool to use.
        The SentinelConnectionPool will be used by default.

        All other arguments are passed directly to the SentinelConnectionPool.
        """
        kwargs['is_main'] = False
        return redis_class(connection_pool=connection_pool_class(
            service_name, self, **kwargs))
