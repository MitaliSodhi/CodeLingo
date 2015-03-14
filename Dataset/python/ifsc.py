import tornado.ioloop
import tornado.web
from json import loads, JSONEncoder, JSONDecoder
import json
import MySQLdb
import re

class QueryHandler(tornado.web.RequestHandler):

	def handle_query(self, query):

		result_list = {}
		result_list['status_code'] = 200
		result_list['status_text'] = "Success"
		result_list['count'] = 0
		result_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="", db="ifsc")
		cursor = db.cursor()

		if query == "banks":
			cursor.execute('SELECT Bank_Name from ifsc_db group by Bank_Name')
			for row in cursor.fetchall():
				result_list['data'].append(re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[0]))
				result_list['count'] += 1

		elif query == "states":
			cursor.execute('SELECT State from ifsc_db group by State')
			for row in cursor.fetchall():
				result_list['data'].append(re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[0]))
				result_list['count'] += 1

		self.write(json.dumps(result_list))

	def handle_ifsc(self, ifsc):
		result_list = {}
		result_list['status_code'] = 200
		result_list['status_text'] = "Success"
		result_list['count'] = 0
		result_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="", db="ifsc")
		cursor = db.cursor()

		cursor.execute('SELECT * from ifsc_db where IFSC_Code=%s', (ifsc))

		for row in cursor.fetchall():
			result = {}
			result['Bank_Name'] = re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[0])
			result['IFSC_Code'] = re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[1])
			result['MICR_Code'] = re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[2])
			result['Branch_Name'] = re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[3])
			result['Address'] = re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[4])
			result['Contact'] = re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[5])
			result['City'] = re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[6])
			result['District'] = re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[7])
			result['State'] = re.sub('[^A-Za-z0-9./,;!@#$%^&*()-_=+<>?: ]+', '', row[8])
			result_list['data'].append(result)
			result_list['count'] += 1

		self.write(json.dumps(result_list))

	def get(self):
		query = self.get_argument('q', None)
		code = self.get_argument('code', None)
		if query == "ifsc":
			self.handle_ifsc(code)
		else:
			self.handle_query(query)



application = tornado.web.Application([
    (r"/ifsc/queryhandler/", QueryHandler),
])

if __name__ == "__main__":
    application.listen(8888)
    tornado.ioloop.IOLoop.instance().start()