# Copyright 2009-2012 10gen, Inc.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

"""Main-Subordinate connection to Mongo.

Performs all writes to Main instance and distributes reads among all
subordinates. Reads are tried on each subordinate in turn until the read succeeds
or all subordinates failed.
"""

from pymongo import helpers, thread_util
from pymongo import ReadPreference
from pymongo.common import BaseObject
from pymongo.mongo_client import MongoClient
from pymongo.database import Database
from pymongo.errors import AutoReconnect


class MainSubordinateConnection(BaseObject):
    """A main-subordinate connection to Mongo.
    """

    def __init__(self, main, subordinates=[], document_class=dict, tz_aware=False):
        """Create a new Main-Subordinate connection.

        The resultant connection should be interacted with using the same
        mechanisms as a regular `MongoClient`. The `MongoClient` instances used
        to create this `MainSubordinateConnection` can themselves make use of
        connection pooling, etc. `MongoClient` instances used as subordinates should
        be created with the read_preference option set to
        :attr:`~pymongo.read_preferences.ReadPreference.SECONDARY`. Write
        concerns are inherited from `main` and can be changed in this
        instance.

        Raises TypeError if `main` is not an instance of `MongoClient` or
        subordinates is not a list of at least one `MongoClient` instances.

        :Parameters:
          - `main`: `MongoClient` instance for the writable Main
          - `subordinates`: list of `MongoClient` instances for the
            read-only subordinates
          - `document_class` (optional): default class to use for
            documents returned from queries on this connection
          - `tz_aware` (optional): if ``True``,
            :class:`~datetime.datetime` instances returned as values
            in a document by this :class:`MainSubordinateConnection` will be timezone
            aware (otherwise they will be naive)
        """
        if not isinstance(main, MongoClient):
            raise TypeError("main must be a MongoClient instance")
        if not isinstance(subordinates, list) or len(subordinates) == 0:
            raise TypeError("subordinates must be a list of length >= 1")

        for subordinate in subordinates:
            if not isinstance(subordinate, MongoClient):
                raise TypeError("subordinate %r is not an instance of MongoClient" %
                                subordinate)

        super(MainSubordinateConnection,
              self).__init__(read_preference=ReadPreference.SECONDARY,
                             safe=main.safe,
                             **main.write_concern)

        self.__main = main
        self.__subordinates = subordinates
        self.__document_class = document_class
        self.__tz_aware = tz_aware
        self.__request_counter = thread_util.Counter(main.use_greenlets)

    @property
    def main(self):
        return self.__main

    @property
    def subordinates(self):
        return self.__subordinates

    @property
    def is_mongos(self):
        """If this MainSubordinateConnection is connected to mongos (always False)

        .. versionadded:: 2.3
        """
        return False

    @property
    def use_greenlets(self):
        """Whether calling :meth:`start_request` assigns greenlet-local,
        rather than thread-local, sockets.

        .. versionadded:: 2.4.2
        """
        return self.main.use_greenlets

    def get_document_class(self):
        return self.__document_class

    def set_document_class(self, klass):
        self.__document_class = klass

    document_class = property(get_document_class, set_document_class,
                              doc="""Default class to use for documents
                              returned on this connection.""")

    @property
    def tz_aware(self):
        return self.__tz_aware

    @property
    def max_bson_size(self):
        """Return the maximum size BSON object the connected main
        accepts in bytes. Defaults to 4MB in server < 1.7.4.

        .. versionadded:: 2.6
        """
        return self.main.max_bson_size

    @property
    def max_message_size(self):
        """Return the maximum message size the connected main
        accepts in bytes.

        .. versionadded:: 2.6
        """
        return self.main.max_message_size


    def disconnect(self):
        """Disconnect from MongoDB.

        Disconnecting will call disconnect on all main and subordinate
        connections.

        .. seealso:: Module :mod:`~pymongo.mongo_client`
        .. versionadded:: 1.10.1
        """
        self.__main.disconnect()
        for subordinate in self.__subordinates:
            subordinate.disconnect()

    def set_cursor_manager(self, manager_class):
        """Set the cursor manager for this connection.

        Helper to set cursor manager for each individual `MongoClient` instance
        that make up this `MainSubordinateConnection`.
        """
        self.__main.set_cursor_manager(manager_class)
        for subordinate in self.__subordinates:
            subordinate.set_cursor_manager(manager_class)

    def _ensure_connected(self, sync):
        """Ensure the main is connected to a mongod/s.
        """
        self.__main._ensure_connected(sync)

    # _connection_to_use is a hack that we need to include to make sure
    # that killcursor operations can be sent to the same instance on which
    # the cursor actually resides...
    def _send_message(self, message,
                      with_last_error=False, _connection_to_use=None):
        """Say something to Mongo.

        Sends a message on the Main connection. This is used for inserts,
        updates, and deletes.

        Raises ConnectionFailure if the message cannot be sent. Returns the
        request id of the sent message.

        :Parameters:
          - `operation`: opcode of the message
          - `data`: data to send
          - `safe`: perform a getLastError after sending the message
        """
        if _connection_to_use is None or _connection_to_use == -1:
            return self.__main._send_message(message, with_last_error)
        return self.__subordinates[_connection_to_use]._send_message(
            message, with_last_error, check_primary=False)

    # _connection_to_use is a hack that we need to include to make sure
    # that getmore operations can be sent to the same instance on which
    # the cursor actually resides...
    def _send_message_with_response(self, message, _connection_to_use=None,
                                    _must_use_main=False, **kwargs):
        """Receive a message from Mongo.

        Sends the given message and returns a (connection_id, response) pair.

        :Parameters:
          - `operation`: opcode of the message to send
          - `data`: data to send
        """
        if _connection_to_use is not None:
            if _connection_to_use == -1:
                member = self.__main
                conn = -1
            else:
                member = self.__subordinates[_connection_to_use]
                conn = _connection_to_use
            return (conn,
                    member._send_message_with_response(message, **kwargs)[1])

        # _must_use_main is set for commands, which must be sent to the
        # main instance. any queries in a request must be sent to the
        # main since that is where writes go.
        if _must_use_main or self.in_request():
            return (-1, self.__main._send_message_with_response(message,
                                                                  **kwargs)[1])

        # Iterate through the subordinates randomly until we have success. Raise
        # reconnect if they all fail.
        for connection_id in helpers.shuffled(xrange(len(self.__subordinates))):
            try:
                subordinate = self.__subordinates[connection_id]
                return (connection_id,
                        subordinate._send_message_with_response(message,
                                                          **kwargs)[1])
            except AutoReconnect:
                pass

        raise AutoReconnect("failed to connect to subordinates")

    def start_request(self):
        """Start a "request".

        Start a sequence of operations in which order matters. Note
        that all operations performed within a request will be sent
        using the Main connection.
        """
        self.__request_counter.inc()
        self.main.start_request()

    def in_request(self):
        return bool(self.__request_counter.get())

    def end_request(self):
        """End the current "request".

        See documentation for `MongoClient.end_request`.
        """
        self.__request_counter.dec()
        self.main.end_request()

    def __eq__(self, other):
        if isinstance(other, MainSubordinateConnection):
            us = (self.__main, self.subordinates)
            them = (other.__main, other.__subordinates)
            return us == them
        return NotImplemented

    def __ne__(self, other):
        return not self == other

    def __repr__(self):
        return "MainSubordinateConnection(%r, %r)" % (self.__main, self.__subordinates)

    def __getattr__(self, name):
        """Get a database by name.

        Raises InvalidName if an invalid database name is used.

        :Parameters:
          - `name`: the name of the database to get
        """
        return Database(self, name)

    def __getitem__(self, name):
        """Get a database by name.

        Raises InvalidName if an invalid database name is used.

        :Parameters:
          - `name`: the name of the database to get
        """
        return self.__getattr__(name)

    def close_cursor(self, cursor_id, connection_id):
        """Close a single database cursor.

        Raises TypeError if cursor_id is not an instance of (int, long). What
        closing the cursor actually means depends on this connection's cursor
        manager.

        :Parameters:
          - `cursor_id`: cursor id to close
          - `connection_id`: id of the `MongoClient` instance where the cursor
            was opened
        """
        if connection_id == -1:
            return self.__main.close_cursor(cursor_id)
        return self.__subordinates[connection_id].close_cursor(cursor_id)

    def database_names(self):
        """Get a list of all database names.
        """
        return self.__main.database_names()

    def drop_database(self, name_or_database):
        """Drop a database.

        :Parameters:
          - `name_or_database`: the name of a database to drop or the object
            itself
        """
        return self.__main.drop_database(name_or_database)

    def __iter__(self):
        return self

    def next(self):
        raise TypeError("'MainSubordinateConnection' object is not iterable")

    def _cached(self, database_name, collection_name, index_name):
        return self.__main._cached(database_name,
                                     collection_name, index_name)

    def _cache_index(self, database_name, collection_name,
                     index_name, cache_for):
        return self.__main._cache_index(database_name, collection_name,
                                          index_name, cache_for)

    def _purge_index(self, database_name,
                     collection_name=None, index_name=None):
        return self.__main._purge_index(database_name,
                                          collection_name,
                                          index_name)
