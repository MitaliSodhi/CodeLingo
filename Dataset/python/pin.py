import json
from pprint import pprint

pincode_file = open('pincode.json')
pincode_json = json.load(pincode_file)

state_list = {}
state_list['states'] = []
state_list['state_count'] = 0

district_list = {}
district_list['state_name'] = ''
district_list['districts'] = []
district_list['districts_count'] = 0

#for line in pincode_json:
#	if line['statename'] not in state_list['states'] and line['statename'] not in "NULL":
#		state_list['states'].append(line['statename'])
#		state_list['state_count'] += 1

#state_list_json = json.dumps(state_list)
#print state_list_json

#for line in pincode_json:
#	if line['statename'] in somevalue:
#		district_list['districts'].append(line['Districtname'])
#		district_list['districts_count'] += 1

pin_list = {}
pin_list['pincode'] = ''
pin_list['places'] = []
pin_list['places_count'] = 0

for line in pincode_json:
	if str(line['pincode']) in str('700124'):
		pin_list['places'].append(line)
		#print json.dumps(line)
		pin_list['places_count'] += 1

state_list_json = json.dumps(pin_list)
print state_list_json