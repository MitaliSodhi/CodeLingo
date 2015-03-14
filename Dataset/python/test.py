import xmltodict, json

json_file = open('nba_2.json')

# o = xmltodict.parse(xml_file)
# p = json.dumps(o, sort_keys=True, indent=4, separators=(',', ': '))
# print p

json_data = json.load(json_file)
count = 0

for line in json_data['PhysicalProgress']['row']:
	if line['State_Name'] == 'Karnataka':
		count += int(line['Anganwadi_Toilets_Objectives'])

print count
