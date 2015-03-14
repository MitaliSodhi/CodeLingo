import tornado.ioloop
import tornado.web
from json import loads, JSONEncoder, JSONDecoder
import json
import MySQLdb

class StateHandler(tornado.web.RequestHandler):

	def all_states(self):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="milk")
		cursor = db.cursor()

		cursor.execute('SELECT * from milk')
		for row in cursor.fetchall():
			s_list = {}
			s_list['State'] = row[0]
			s_list['Cow_Milk_2009_2010'] = row[1]
			s_list['Cow_Milk_2010_2011'] = row[2]
			s_list['Buffalo_Milk_2009_2010'] = row[3]
			s_list['Buffalo_Milk_2010_2011'] = row[4]
			s_list['Goat_Milk_2009_2010'] = row[5]
			s_list['Goat_Milk_2010_2011'] = row[6]
			s_list['Total_2009_2010'] = row[7]
			s_list['Total_2010_2011'] = row[8]
			state_list['data'].append(s_list)
			state_list['count'] += 1

		self.write(json.dumps(state_list))

	def specific_states(self, state):
		state = state.replace('+', ' ')
		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="milk")
		cursor = db.cursor()

		cursor.execute('SELECT * from milk where State=%s', (state))
		for row in cursor.fetchall():
			s_list = {}
			s_list['State'] = row[0]
			s_list['Cow_Milk_2009_2010'] = row[1]
			s_list['Cow_Milk_2010_2011'] = row[2]
			s_list['Buffalo_Milk_2009_2010'] = row[3]
			s_list['Buffalo_Milk_2010_2011'] = row[4]
			s_list['Goat_Milk_2009_2010'] = row[5]
			s_list['Goat_Milk_2010_2011'] = row[6]
			s_list['Total_2009_2010'] = row[7]
			s_list['Total_2010_2011'] = row[8]
			state_list['data'].append(s_list)
			state_list['count'] += 1

		self.write(json.dumps(state_list))

	def get(self):
		state_name = self.get_argument('state_name', None)
		if not state_name:
			self.all_states()
		if state_name:
			self.specific_states(state_name)

class YearHandler(tornado.web.RequestHandler):

	def all_year(self, year):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="milk")
		cursor = db.cursor()

		if year == "2009_2010":
			cursor.execute('SELECT * from milk')
			for row in cursor.fetchall():
				s_list = {}
				s_list['State'] = row[0]
				s_list['Cow_Milk_2009_2010'] = row[1]
				s_list['Buffalo_Milk_2009_2010'] = row[3]
				s_list['Goat_Milk_2009_2010'] = row[5]
				s_list['Total_2009_2010'] = row[7]
				state_list['data'].append(s_list)
				state_list['count'] += 1

			self.write(json.dumps(state_list))

		else:
			cursor.execute('SELECT * from milk')
			for row in cursor.fetchall():
				s_list = {}
				s_list['State'] = row[0]
				s_list['Cow_Milk_2010_2011'] = row[2]
				s_list['Buffalo_Milk_2010_2011'] = row[4]
				s_list['Goat_Milk_2010_2011'] = row[6]
				s_list['Total_2010_2011'] = row[8]
				state_list['data'].append(s_list)
				state_list['count'] += 1

			self.write(json.dumps(state_list))

	def specific_year(self, year, state):
		state = state.replace('+', ' ')
		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="milk")
		cursor = db.cursor()

		if year == "2009_2010":
			cursor.execute('SELECT * from milk where State=%s', (state))
			for row in cursor.fetchall():
				s_list = {}
				s_list['State'] = row[0]
				s_list['Cow_Milk_2009_2010'] = row[1]
				s_list['Buffalo_Milk_2009_2010'] = row[3]
				s_list['Goat_Milk_2009_2010'] = row[5]
				s_list['Total_2009_2010'] = row[7]
				state_list['data'].append(s_list)
				state_list['count'] += 1

			self.write(json.dumps(state_list))

		else:
			cursor.execute('SELECT * from milk where State=%s', (state))
			for row in cursor.fetchall():
				s_list = {}
				s_list['State'] = row[0]
				s_list['Cow_Milk_2010_2011'] = row[2]
				s_list['Buffalo_Milk_2010_2011'] = row[4]
				s_list['Goat_Milk_2010_2011'] = row[6]
				s_list['Total_2010_2011'] = row[8]
				state_list['data'].append(s_list)
				state_list['count'] += 1

			self.write(json.dumps(state_list))

	def get(self):
		state_name = self.get_argument('state_name', None)
		year = self.get_argument('year', None)
		if not state_name:
			self.all_year(year)
		if state_name:
			self.specific_year(year, state_name)

class AnimalHandler(tornado.web.RequestHandler):

	def all_states(self, animal):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="milk")
		cursor = db.cursor()

		if animal == "cow":
			cursor.execute('SELECT * from milk')
			for row in cursor.fetchall():
				s_list = {}
				s_list['State'] = row[0]
				s_list['Cow_Milk_2009_2010'] = row[1]
				s_list['Cow_Milk_2010_2011'] = row[2]
				state_list['data'].append(s_list)
				state_list['count'] += 1

			self.write(json.dumps(state_list))

		elif animal == "buffalo":
			cursor.execute('SELECT * from milk')
			for row in cursor.fetchall():
				s_list = {}
				s_list['State'] = row[0]
				s_list['Buffalo_Milk_2009_2010'] = row[3]
				s_list['Buffalo_Milk_2010_2011'] = row[4]
				state_list['data'].append(s_list)
				state_list['count'] += 1

			self.write(json.dumps(state_list))

		else:
			cursor.execute('SELECT * from milk')
			for row in cursor.fetchall():
				s_list = {}
				s_list['State'] = row[0]
				s_list['Goat_Milk_2009_2010'] = row[5]
				s_list['Goat_Milk_2010_2011'] = row[6]
				state_list['data'].append(s_list)
				state_list['count'] += 1

			self.write(json.dumps(state_list))

	def specific_states(self, animal, state):
		state = state.replace('+', ' ')
		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="milk")
		cursor = db.cursor()

		if animal == "cow":
			cursor.execute('SELECT * from milk where State=%s', (state))
			for row in cursor.fetchall():
				s_list = {}
				s_list['State'] = row[0]
				s_list['Cow_Milk_2009_2010'] = row[1]
				s_list['Cow_Milk_2010_2011'] = row[2]
				state_list['data'].append(s_list)
				state_list['count'] += 1

			self.write(json.dumps(state_list))

		elif animal == "buffalo":
			cursor.execute('SELECT * from milk where State=%s', (state))
			for row in cursor.fetchall():
				s_list = {}
				s_list['State'] = row[0]
				s_list['Buffalo_Milk_2009_2010'] = row[3]
				s_list['Buffalo_Milk_2010_2011'] = row[4]
				state_list['data'].append(s_list)
				state_list['count'] += 1

			self.write(json.dumps(state_list))

		else:
			cursor.execute('SELECT * from milk where State=%s', (state))
			for row in cursor.fetchall():
				s_list = {}
				s_list['State'] = row[0]
				s_list['Goat_Milk_2009_2010'] = row[5]
				s_list['Goat_Milk_2010_2011'] = row[6]
				state_list['data'].append(s_list)
				state_list['count'] += 1

			self.write(json.dumps(state_list))

	def get(self):
		state_name = self.get_argument('state_name', None)
		animal = self.get_argument('animal', None)
		if not state_name:
			self.all_states(animal)
		if state_name:
			self.specific_states(animal, state_name)

application = tornado.web.Application([
    (r"/milk/statewise/", StateHandler),
    (r"/milk/yearwise/", YearHandler),
    (r"/milk/animalwise/", AnimalHandler),
])

if __name__ == "__main__":
    application.listen(8888)
    tornado.ioloop.IOLoop.instance().start()