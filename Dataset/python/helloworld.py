import tornado.ioloop
import tornado.web
import json
import MySQLdb

class MainHandler(tornado.web.RequestHandler):

	def fetch_results(self, arg1, arg2):
		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="nba")
		cursor = db.cursor()

		if arg2 == 'states':
			state_list = {}
			state_list['states'] = []
			state_list['state_count'] = 0
			cursor.execute("SELECT State_Name FROM nba group by State_Name")
			for row in cursor.fetchall():
				state_list['states'].append(row[0])
				state_list['state_count'] += 1
			self.write(json.dumps(state_list))

		if arg2 == 'districts':
			statename = arg1.replace('+', ' ')
			district_list = {}
			district_list['state_name'] = statename
			district_list['districts'] = []
			district_list['districts_count'] = 0
			cursor.execute("SELECT District_Name FROM nba where State_Name=%s", (statename))
			for row in cursor.fetchall():
				district_list['districts'].append(row[0])
				district_list['districts_count'] += 1
			self.write(json.dumps(district_list))

		if arg2 == 'progress':
			argument_list = arg1.split(",")
			progress_list = {}
			progress_list['parameters'] = {}
			progress_list['state_name'] = argument_list[0].replace('+', ' ')
			progress_list['district_name'] = argument_list[1].replace('+', ' ')
			progress_list['count'] = 0
			if argument_list[2] == 'all':
				cursor.execute("SELECT * FROM nba where State_Name=%s and District_Name=%s", (argument_list[0].replace('+', ' '), argument_list[1].replace('+', ' ')))
				for row in cursor.fetchall():
					progress_list['parameters']['Anganwadi_Toilets_Objectives'] = row[2]
					progress_list['parameters']['IHHL_APL_Objectives'] = row[3]
					progress_list['parameters']['IHHL_BPL_Objectives'] = row[4]
					progress_list['parameters']['IHHL_TOTAL_Objectives'] = row[5]
					progress_list['parameters']['Production_Centre_Objectives'] = row[6]
					progress_list['parameters']['Rural_Sanitary_Mart_Objectives'] = row[7]
					progress_list['parameters']['SCW_Objectives'] = row[8]
					progress_list['parameters']['School_Toilets_Objectives'] = row[9]
					progress_list['parameters']['Anganwadi_Toilets_Performance'] = row[10]
					progress_list['parameters']['IHHL_APL_Performance'] = row[11]
					progress_list['parameters']['IHHL_BPL_Performance'] = row[12]
					progress_list['parameters']['IHHL_TOTAL_Performance'] = row[13]
					progress_list['parameters']['Production_Centre_Performance'] = row[14]
					progress_list['parameters']['Rural_Sanitary_Mart_Performance'] = row[15]
					progress_list['parameters']['SCW_Performance'] = row[16]
					progress_list['parameters']['School_Toilets_Performance'] = row[17]
					progress_list['count'] += 1
				self.write(json.dumps(progress_list))
			if argument_list[2] == 'objectives':
				cursor.execute("SELECT * FROM nba where State_Name=%s and District_Name=%s", (argument_list[0].replace('+', ' '), argument_list[1].replace('+', ' ')))
				for row in cursor.fetchall():
					progress_list['parameters']['Anganwadi_Toilets_Objectives'] = row[2]
					progress_list['parameters']['IHHL_APL_Objectives'] = row[3]
					progress_list['parameters']['IHHL_BPL_Objectives'] = row[4]
					progress_list['parameters']['IHHL_TOTAL_Objectives'] = row[5]
					progress_list['parameters']['Production_Centre_Objectives'] = row[6]
					progress_list['parameters']['Rural_Sanitary_Mart_Objectives'] = row[7]
					progress_list['parameters']['SCW_Objectives'] = row[8]
					progress_list['parameters']['School_Toilets_Objectives'] = row[9]
					progress_list['count'] += 1
				self.write(json.dumps(progress_list))
			if argument_list[2] == 'performance':
				cursor.execute("SELECT * FROM nba where State_Name=%s and District_Name=%s", (argument_list[0].replace('+', ' '), argument_list[1].replace('+', ' ')))
				for row in cursor.fetchall():
					progress_list['parameters']['Anganwadi_Toilets_Performance'] = row[10]
					progress_list['parameters']['IHHL_APL_Performance'] = row[11]
					progress_list['parameters']['IHHL_BPL_Performance'] = row[12]
					progress_list['parameters']['IHHL_TOTAL_Performance'] = row[13]
					progress_list['parameters']['Production_Centre_Performance'] = row[14]
					progress_list['parameters']['Rural_Sanitary_Mart_Performance'] = row[15]
					progress_list['parameters']['SCW_Performance'] = row[16]
					progress_list['parameters']['School_Toilets_Performance'] = row[17]
					progress_list['count'] += 1
				self.write(json.dumps(progress_list))

	def get(self):
		states = self.get_argument('states', None)
		districts = self.get_argument('districts', None)
		progress = self.get_argument('progress', None)

		if not districts and not progress:
			self.fetch_results(None, 'states')
		if districts and not states and not progress:
			self.fetch_results(self.get_argument('districts'), 'districts')
		if progress and states and districts:
			self.fetch_results(self.get_argument('states')+","+self.get_argument('districts')+","+self.get_argument('progress'), 'progress')
			
	def write_error(self, status_code, **kwargs):
		self.write("Look at that! You caused a %d error." % status_code)

application = tornado.web.Application([
    (r"/nba", MainHandler),
])

if __name__ == "__main__":
    application.listen(8888)
    tornado.ioloop.IOLoop.instance().start()