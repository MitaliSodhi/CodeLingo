import json
import MySQLdb

db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="pincode")
cursor = db.cursor()

pin_file = open('pincode.json')

pin_json = json.load(pin_file)

for line in pin_json:
	officename = str(line['officename']).encode("utf-8")
	pincode = int(line['pincode'])
	officeType = str(line['officeType']).encode("utf-8")
	Deliverystatus = str(line['Deliverystatus']).encode("utf-8")
	divisionname = str(line['divisionname']).encode("utf-8")
	regionname = str(line['regionname']).encode("utf-8")
	circlename = str(line['circlename']).encode("utf-8")
	Taluk = str(line['Taluk']).encode("utf-8")
	Districtname = str(line['Districtname']).encode("utf-8")
	statename = str(line['statename']).encode("utf-8")

	cursor.execute('''INSERT into pincode (officename, pincode, officeType, Deliverystatus, divisionname, regionname, circlename, Taluk, Districtname, statename) values (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s)''', (officename, pincode, officeType, Deliverystatus, divisionname, regionname, circlename, Taluk, Districtname, statename))
	db.commit()

#cursor.execute("SELECT District_Name FROM nba where State_Name=%s", ('West Bengal'))
#for row in cursor.fetchall():
#	print row[0]