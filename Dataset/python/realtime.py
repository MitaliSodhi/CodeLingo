import tornado.ioloop
import tornado.web
import MySQLdb
import json
import urllib2
import datetime
import time
import requests
from time import strftime

class MainHandler(tornado.web.RequestHandler):

	def realtime_report(self, dataset):
		report_list = {}

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="dataweave")
		cursor = db.cursor()

		api_list = {}
		cursor.execute('SELECT api_url from api_list where api_name=%s', (dataset));
		for row in cursor.fetchall():
			api_url = row[0]

		start_time = time.time()
		response = requests.get(api_url)
		load_time = time.time() - start_time
		content = response.text
		json_content = json.loads(content)
		print json_content['status_text'], json_content['status_code'], json_content['count']
		now = datetime.datetime.now()
		print load_time

		report_list['api_name'] = dataset
		report_list['crawl_date'] = str(now).split()[0]
		report_list['crawl_time'] = strftime("%H:%M:%S")
		report_list['status_text'] = json_content['status_text']
		report_list['status_code'] = json_content['status_code']
		report_list['result_count'] = json_content['count']
		report_list['response_time'] = load_time

		self.write(json.dumps(report_list))

	def historical_report(self):
		api_list = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="dataweave")
		cursor = db.cursor()

		cursor.execute('SELECT api_name, max(response_time), min(response_time), avg(response_time) from dw_api_tracking group by api_name');
		for row in cursor.fetchall():
			report_list = {}
			report_list['api_name'] = str(row[0])
			report_list['max_response_time'] = "%.2f" % round(float(row[1]), 2)
			report_list['min_response_time'] = "%.2f" % round(float(row[2]), 2)
			report_list['avg_response_time'] = "%.2f" % round(float(row[3]), 2)
			api_list.append(report_list)

		self.write(json.dumps(api_list))

	def historical_report_parameterized(self, max_date, min_date, dataset):
		api_list = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="dataweave")
		cursor = db.cursor()

		cursor.execute('SELECT api_name, max(response_time), min(response_time), avg(response_time) from dw_api_tracking where api_name=%s and crawl_date BETWEEN %s AND %s group by api_name', (dataset, min_date, max_date));
		for row in cursor.fetchall():
			report_list = {}
			report_list['api_name'] = str(row[0])
			report_list['max_response_time'] = "%.2f" % round(float(row[1]), 2)
			report_list['min_response_time'] = "%.2f" % round(float(row[2]), 2)
			report_list['avg_response_time'] = "%.2f" % round(float(row[3]), 2)
			api_list.append(report_list)

		self.write(json.dumps(api_list))

	def get(self):
		dataset = self.get_argument('api', None)
		metric = self.get_argument('metric', None)
		max_date = self.get_argument('max_date', None)
		min_date = self.get_argument('min_date', None)
		if metric == 'current':
			self.realtime_report(dataset)
		if metric == 'historical' and not max_date and not min_date:
			self.historical_report()
		if metric == 'historical' and max_date and min_date:
			self.historical_report_parameterized(max_date, min_date, dataset)


application = tornado.web.Application([
    (r"/health/", MainHandler),
])

if __name__ == "__main__":
    application.listen(8888)
    tornado.ioloop.IOLoop.instance().start()