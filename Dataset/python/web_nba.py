import tornado.ioloop
import tornado.web
from json import loads, JSONEncoder, JSONDecoder
import json
import MySQLdb
import pickle
import jsonpickle

class StateHandler(tornado.web.RequestHandler):

	def all_states(self):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="national_park")
		cursor = db.cursor()

		cursor.execute('SELECT * from national_park')
		for row in cursor.fetchall():
			s_list = {}
			s_list['State_Name'] = str(row[0])
			s_list['National_Parks_Number'] = int(row[1])
			s_list['National_Parks_Area'] = float(row[2])
			s_list['Wildlife_Sanctuaries_Number'] = int(row[3])
			s_list['Wildlife_Sanctuaries_Area'] = float(row[4])
			state_list['data'].append(s_list)
			state_list['count'] += 1

		self.write(json.dumps(state_list))

	def specific_states(self, state):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="national_park")
		cursor = db.cursor()

		cursor.execute('SELECT * from national_park where States=%s', (state))
		for row in cursor.fetchall():
			s_list = {}
			s_list['State_Name'] = str(row[0])
			s_list['National_Parks_Number'] = int(row[1])
			s_list['National_Parks_Area'] = float(row[2])
			s_list['Wildlife_Sanctuaries_Number'] = int(row[3])
			s_list['Wildlife_Sanctuaries_Area'] = float(row[4])
			state_list['data'].append(s_list)
			state_list['count'] += 1

		self.write(json.dumps(state_list))

	def get(self):
		state_name = self.get_argument('state_name', None)
		if not state_name:
			self.all_states()
		if state_name:
			self.specific_states(state_name)

class SBPHandler(tornado.web.RequestHandler):

	def national_parks_by_parameters(self, national_parks_max, national_parks_min, national_parks_area_max, national_parks_area_min, wildlife_sanctuaries_max, wildlife_sanctuaries_min, wildlife_sanctuaries_area_max, wildlife_sanctuaries_area_min):

		state_list = {}
		state_list['count'] = 0
		state_list['status_text'] = "Success"
		state_list['status_code'] = 200
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="national_park")
		cursor = db.cursor()

		cursor.execute('SELECT * from national_park where National_Parks_Number BETWEEN %s AND %s AND National_Parks_Area BETWEEN %s and %s AND Wildlife_Sanctuaries_Number BETWEEN %s AND %s AND Wildlife_Sanctuaries_Area BETWEEN %s AND %s', (national_parks_min, national_parks_max, national_parks_area_min, national_parks_area_max, wildlife_sanctuaries_min, wildlife_sanctuaries_max, wildlife_sanctuaries_area_min, wildlife_sanctuaries_area_max))

		for row in cursor.fetchall():
			s_list = {}
			s_list['State_Name'] = str(row[0])
			s_list['National_Parks_Number'] = int(row[1])
			s_list['National_Parks_Area'] = float(row[2])
			s_list['Wildlife_Sanctuaries_Number'] = int(row[3])
			s_list['Wildlife_Sanctuaries_Area'] = float(row[4])
			state_list['data'].append(s_list)
			state_list['count'] += 1

		self.write(json.dumps(state_list))

	def get(self):
		national_parks_max = self.get_argument('national_parks_max', None)
		national_parks_min = self.get_argument('national_parks_min', None)

		national_parks_area_max = self.get_argument('national_parks_area_max', None)
		national_parks_area_min = self.get_argument('national_parks_area_min', None)

		wildlife_sanctuaries_max = self.get_argument('wildlife_sanctuaries_max', None)
		wildlife_sanctuaries_min = self.get_argument('wildlife_sanctuaries_min', None)

		wildlife_sanctuaries_area_max = self.get_argument('wildlife_sanctuaries_area_max', None)
		wildlife_sanctuaries_area_min = self.get_argument('wildlife_sanctuaries_area_min', None)

		if not national_parks_max:
			national_parks_max = 9999999
		if not national_parks_min:
			national_parks_min = -1
		if not wildlife_sanctuaries_max:
			wildlife_sanctuaries_max = 9999999
		if not wildlife_sanctuaries_min:
			wildlife_sanctuaries_min = -1

		if not national_parks_area_max:
			national_parks_area_max = 9999999
		if not national_parks_area_min:
			national_parks_area_min = -1
		if not wildlife_sanctuaries_area_max:
			wildlife_sanctuaries_area_max = 9999999
		if not wildlife_sanctuaries_area_min:
			wildlife_sanctuaries_area_min = -1
		
		self.national_parks_by_parameters(national_parks_max, national_parks_min, national_parks_area_max, national_parks_area_min, wildlife_sanctuaries_max, wildlife_sanctuaries_min, wildlife_sanctuaries_area_max, wildlife_sanctuaries_area_min)

application = tornado.web.Application([
    (r"/national_parks/states/", StateHandler),
    (r"/national_parks/statsbyparameter/", SBPHandler), 
])

if __name__ == "__main__":
    application.listen(8888)
    tornado.ioloop.IOLoop.instance().start()