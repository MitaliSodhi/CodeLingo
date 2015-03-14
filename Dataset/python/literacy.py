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

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="literacy")
		cursor = db.cursor()

		cursor.execute('SELECT * from literacy')
		for row in cursor.fetchall():
			s_list = {}
			s_list['State_Name'] = str(row[0]).encode('utf-8')
			s_list['Literate_Persons_1991'] = row[1]
			s_list['Literate_Male_1991'] = row[2]
			s_list['Literate_Female_1991'] = row[3]
			s_list['Literate_Persons_2001'] = row[4]
			s_list['Literate_Male_2001'] = row[5]
			s_list['Literate_Female_2001'] = row[6]
			s_list['Literate_Persons_2011'] = row[7]
			s_list['Literate_Male_2011'] = row[8]
			s_list['Literate_Female_2011'] = row[9]
			s_list['Literate_Male_Rural'] = row[10]
			s_list['Literate_Female_Rural'] = row[11]
			s_list['Literate_Persons_Rural'] = row[12]
			s_list['Literate_Male_Urban'] = row[13]
			s_list['Literate_Female_Urban'] = row[14]
			s_list['Literate_Persons_Urban'] = row[15]
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

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="literacy")
		cursor = db.cursor()

		cursor.execute('SELECT * from literacy where State_Name=%s', (state))
		for row in cursor.fetchall():
			s_list = {}
			s_list['State_Name'] = str(row[0]).encode('utf-8')
			s_list['Literate_Persons_1991'] = row[1]
			s_list['Literate_Male_1991'] = row[2]
			s_list['Literate_Female_1991'] = row[3]
			s_list['Literate_Persons_2001'] = row[4]
			s_list['Literate_Male_2001'] = row[5]
			s_list['Literate_Female_2001'] = row[6]
			s_list['Literate_Persons_2011'] = row[7]
			s_list['Literate_Male_2011'] = row[8]
			s_list['Literate_Female_2011'] = row[9]
			s_list['Literate_Male_Rural'] = row[10]
			s_list['Literate_Female_Rural'] = row[11]
			s_list['Literate_Persons_Rural'] = row[12]
			s_list['Literate_Male_Urban'] = row[13]
			s_list['Literate_Female_Urban'] = row[14]
			s_list['Literate_Persons_Urban'] = row[15]
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

	def displayyearwise(self, year):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="literacy")
		cursor = db.cursor()

		cursor.execute('SELECT * from literacy')

		if year == "1991":
			for row in cursor.fetchall():
				s_list = {}
				s_list['State_Name'] = str(row[0]).encode('utf-8')
				s_list['Literate_Persons_1991'] = row[1]
				s_list['Literate_Male_1991'] = row[2]
				s_list['Literate_Female_1991'] = row[3]
				state_list['data'].append(s_list)
				state_list['count'] += 1
			self.write(json.dumps(state_list))

		elif year == "2001":
			for row in cursor.fetchall():
				s_list = {}
				s_list['State_Name'] = str(row[0]).encode('utf-8')
				s_list['Literate_Persons_2001'] = row[4]
				s_list['Literate_Male_2001'] = row[5]
				s_list['Literate_Female_2001'] = row[6]
				state_list['data'].append(s_list)
				state_list['count'] += 1
			self.write(json.dumps(state_list))

		elif year == "2011":
			for row in cursor.fetchall():
				s_list = {}
				s_list['State_Name'] = str(row[0]).encode('utf-8')
				s_list['Literate_Persons_2011'] = row[7]
				s_list['Literate_Male_2011'] = row[8]
				s_list['Literate_Female_2011'] = row[9]
				state_list['data'].append(s_list)
				state_list['count'] += 1
			self.write(json.dumps(state_list))

	def get(self):
		year = self.get_argument('year', None)
		self.displayyearwise(year)

class RuralHandler(tornado.web.RequestHandler):

	def displayrural(self):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="literacy")
		cursor = db.cursor()

		cursor.execute('SELECT * from literacy')

		for row in cursor.fetchall():
			s_list = {}
			s_list['State_Name'] = str(row[0]).encode('utf-8')
			s_list['Literate_Male_Rural'] = row[10]
			s_list['Literate_Female_Rural'] = row[11]
			s_list['Literate_Persons_Rural'] = row[12]
			state_list['data'].append(s_list)
			state_list['count'] += 1

		self.write(json.dumps(state_list))

	def get(self):
		self.displayrural()

class UrbanHandler(tornado.web.RequestHandler):

	def displayurban(self):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="literacy")
		cursor = db.cursor()

		cursor.execute('SELECT * from literacy')

		for row in cursor.fetchall():
			s_list = {}
			s_list['State_Name'] = str(row[0]).encode('utf-8')
			s_list['Literate_Male_Urban'] = row[13]
			s_list['Literate_Female_Urban'] = row[14]
			s_list['Literate_Persons_Urban'] = row[15]
			state_list['data'].append(s_list)
			state_list['count'] += 1

		self.write(json.dumps(state_list))

	def get(self):
		self.displayurban()

class GenderHandler(tornado.web.RequestHandler):

	def displaygender(self, gender):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="literacy")
		cursor = db.cursor()

		cursor.execute('SELECT * from literacy')

		if gender == "all":
			for row in cursor.fetchall():
				s_list = {}
				s_list['State_Name'] = str(row[0]).encode('utf-8')
				s_list['Literate_Persons_1991'] = row[1]
				s_list['Literate_Male_1991'] = row[2]
				s_list['Literate_Female_1991'] = row[3]
				s_list['Literate_Persons_2001'] = row[4]
				s_list['Literate_Male_2001'] = row[5]
				s_list['Literate_Female_2001'] = row[6]
				s_list['Literate_Persons_2011'] = row[7]
				s_list['Literate_Male_2011'] = row[8]
				s_list['Literate_Female_2011'] = row[9]
				s_list['Literate_Male_Rural'] = row[10]
				s_list['Literate_Female_Rural'] = row[11]
				s_list['Literate_Persons_Rural'] = row[12]
				s_list['Literate_Male_Urban'] = row[13]
				s_list['Literate_Female_Urban'] = row[14]
				s_list['Literate_Persons_Urban'] = row[15]
				state_list['data'].append(s_list)
				state_list['count'] += 1
			self.write(json.dumps(state_list))

		elif gender == "male":
			for row in cursor.fetchall():
				s_list = {}
				s_list['State_Name'] = str(row[0]).encode('utf-8')
				s_list['Literate_Male_1991'] = row[2]
				s_list['Literate_Male_2001'] = row[5]
				s_list['Literate_Male_2011'] = row[8]
				s_list['Literate_Male_Rural'] = row[10]
				s_list['Literate_Male_Urban'] = row[13]
				state_list['data'].append(s_list)
				state_list['count'] += 1
			self.write(json.dumps(state_list))

		elif gender == "female":
			for row in cursor.fetchall():
				s_list = {}
				s_list['State_Name'] = str(row[0]).encode('utf-8')
				s_list['Literate_Female_1991'] = row[3]
				s_list['Literate_Female_2001'] = row[6]
				s_list['Literate_Female_2011'] = row[9]
				s_list['Literate_Female_Rural'] = row[11]
				s_list['Literate_Female_Urban'] = row[14]
				state_list['data'].append(s_list)
				state_list['count'] += 1
			self.write(json.dumps(state_list))

		elif gender == "persons":
			for row in cursor.fetchall():
				s_list = {}
				s_list['State_Name'] = str(row[0]).encode('utf-8')
				s_list['Literate_Persons_1991'] = row[1]
				s_list['Literate_Persons_2001'] = row[4]
				s_list['Literate_Persons_2011'] = row[7]
				s_list['Literate_Persons_Rural'] = row[12]
				s_list['Literate_Persons_Urban'] = row[15]
				state_list['data'].append(s_list)
				state_list['count'] += 1
			self.write(json.dumps(state_list))

	def get(self):
		gender = self.get_argument('gender', None)

		if not gender:
			gender = "all"

		self.displaygender(gender)

class IndiaHandler(tornado.web.RequestHandler):

	def display_india_all(self, gender, location):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="literacy")
		cursor = db.cursor()

		cursor.execute('SELECT * from literacy_india')

		if location == "all":
			if gender == "all":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Rural'] = row[1]
					s_list['Literate_Female_Rural'] = row[2]
					s_list['Literate_Persons_Rural'] = row[3]
					s_list['Literate_Male_Urban'] = row[4]
					s_list['Literate_Female_Urban'] = row[5]
					s_list['Literate_Persons_Urban'] = row[6]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "male":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Rural'] = row[1]
					s_list['Literate_Male_Urban'] = row[4]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "female":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Female_Rural'] = row[2]
					s_list['Literate_Female_Urban'] = row[5]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "persons":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Persons_Rural'] = row[3]
					s_list['Literate_Persons_Urban'] = row[6]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

		if location == "rural":
			if gender == "all":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Rural'] = row[1]
					s_list['Literate_Female_Rural'] = row[2]
					s_list['Literate_Persons_Rural'] = row[3]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "male":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Rural'] = row[1]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "female":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Female_Rural'] = row[2]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "persons":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Persons_Rural'] = row[3]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

		if location == "urban":
			if gender == "all":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Urban'] = row[4]
					s_list['Literate_Female_Urban'] = row[5]
					s_list['Literate_Persons_Urban'] = row[6]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "male":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Urban'] = row[4]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "female":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Female_Urban'] = row[5]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "persons":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Persons_Urban'] = row[6]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

	def display_india(self, year, gender, location):

		state_list = {}
		state_list['status_code'] = 200
		state_list['status_text'] = "Success"
		state_list['count'] = 0
		state_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="literacy")
		cursor = db.cursor()

		cursor.execute('SELECT * from literacy_india where Year=%s', (year))

		if location == "all":
			if gender == "all":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Rural'] = row[1]
					s_list['Literate_Female_Rural'] = row[2]
					s_list['Literate_Persons_Rural'] = row[3]
					s_list['Literate_Male_Urban'] = row[4]
					s_list['Literate_Female_Urban'] = row[5]
					s_list['Literate_Persons_Urban'] = row[6]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "male":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Rural'] = row[1]
					s_list['Literate_Male_Urban'] = row[4]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "female":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Female_Rural'] = row[2]
					s_list['Literate_Female_Urban'] = row[5]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "persons":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Persons_Rural'] = row[3]
					s_list['Literate_Persons_Urban'] = row[6]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

		if location == "rural":
			if gender == "all":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Rural'] = row[1]
					s_list['Literate_Female_Rural'] = row[2]
					s_list['Literate_Persons_Rural'] = row[3]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "male":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Rural'] = row[1]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "female":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Female_Rural'] = row[2]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "persons":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Persons_Rural'] = row[3]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

		if location == "urban":
			if gender == "all":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Urban'] = row[4]
					s_list['Literate_Female_Urban'] = row[5]
					s_list['Literate_Persons_Urban'] = row[6]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "male":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Male_Urban'] = row[4]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "female":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Female_Urban'] = row[5]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))

			elif gender == "persons":
				for row in cursor.fetchall():
					s_list = {}
					s_list['Year'] = row[0]
					s_list['Literate_Persons_Urban'] = row[6]
					state_list['data'].append(s_list)
					state_list['count'] += 1
				self.write(json.dumps(state_list))


	def get(self):
		year = self.get_argument('year', None)
		gender = self.get_argument('gender', None)
		location = self.get_argument('location', None)

		if not location:
			location = "all"

		if not gender:
			gender = "all"

		if not year:
			self.display_india_all(gender, location)
		else:
			self.display_india(year, gender, location)

application = tornado.web.Application([
    (r"/literacy/statewise/", StateHandler),
    (r"/literacy/yearwise/", YearHandler),
    (r"/literacy/genderwise/", GenderHandler),
    (r"/literacy/rural/", RuralHandler),
    (r"/literacy/urban/", UrbanHandler),
    (r"/literacy/india/", IndiaHandler),
])

if __name__ == "__main__":
    application.listen(8888)
    tornado.ioloop.IOLoop.instance().start()