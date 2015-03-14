import tornado.ioloop
import tornado.web
import json
import MySQLdb

class MainHandler(tornado.web.RequestHandler):

	# def fetch_states(self):
	# 	pincode_file = open('pincode.json')
	# 	pincode_json = json.load(pincode_file)

	# 	state_list = {}
	# 	state_list['states'] = []
	# 	state_list['state_count'] = 0

	# 	for line in pincode_json:
	# 		if line['statename'] not in state_list['states'] and line['statename'] not in "NULL":
	# 			state_list['states'].append(line['statename'])
	# 			state_list['state_count'] += 1

	# 	state_list_json = json.dumps(state_list)
	# 	pincode_file.close()

	# 	return state_list_json

	# def fetch_districts(self, statename):
	# 	statename = statename.replace('+', ' ')
	# 	pincode_file = open('pincode.json')
	# 	pincode_json = json.load(pincode_file)

	# 	district_list = {}
	# 	district_list['state_name'] = statename
	# 	district_list['districts'] = []
	# 	district_list['districts_count'] = 0

	# 	for line in pincode_json:
	# 		if line['statename'] in statename and line['Districtname'] not in district_list['districts']:
	# 			district_list['districts'].append(line['Districtname'])
	# 			district_list['districts_count'] += 1

	# 	state_list_json = json.dumps(district_list)
	# 	pincode_file.close()

	# 	return state_list_json

	# def fetch_places_by_pin(self, pincode):
	# 	pincode_file = open('pincode.json')
	# 	pincode_json = json.load(pincode_file)

	# 	pin_list = {}
	# 	pin_list['pincode'] = pincode
	# 	pin_list['places'] = []
	# 	pin_list['places_count'] = 0

	# 	for line in pincode_json:
	# 		if str(line['pincode']) in pincode:
	# 			pin_list['places'].append(line)
	# 			pin_list['places_count'] += 1

	# 	state_list_json = json.dumps(pin_list)
	# 	pincode_file.close()

	# 	return state_list_json

	def fetch_pincode(self, pincode):
		place_list = {}
		place_list['status'] = 200
		place_list['status_text'] = "Success"
		place_list['count'] = 0
		place_list['data'] = []

		db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="pincode")
		cursor = db.cursor()

		cursor.execute('SELECT * from pincode where pincode=%s', (pincode));

		for row in cursor.fetchall():
			s_list = {}
			s_list['Office_Name'] = row[0]
			s_list['Pincode'] = int(row[1])
			s_list['Office_Type'] = row[2]
			s_list['Delivery_Status'] = row[3]
			s_list['Division_Name'] = row[4]
			s_list['Region_Name'] = row[5]
			s_list['Circle_Name'] = row[6]
			s_list['Taluk'] = row[7]
			s_list['District_Name'] = row[8]
			s_list['State_Name'] = row[9]
			place_list['data'].append(s_list)
			place_list['count'] += 1

		self.write(json.dumps(place_list))

	def get(self):
		#states = self.get_argument('states', None)
		#districts = self.get_argument('districts', None)
		pin = self.get_argument('pin', None)

		if pin:
			self.fetch_pincode(pin)
		#if not districts and not pin:
		#	self.write(self.fetch_states())
		#if districts and not pin and not states:
		#	self.write(self.fetch_districts(self.get_argument('districts')))
		#if pin and not districts and not states:
		#	self.write(self.fetch_places_by_pin(self.get_argument('pincode')))



application = tornado.web.Application([
    (r"/pincode/", MainHandler),
])

if __name__ == "__main__":
    application.listen(8888)
    tornado.ioloop.IOLoop.instance().start()