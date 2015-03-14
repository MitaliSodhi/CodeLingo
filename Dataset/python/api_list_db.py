import MySQLdb

api_file = open('api_list').readlines()

api_list = {}
for line in api_file:
	api_list[line.split()[0].strip()] = line.split()[1].strip()

db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="dataweave")
cursor = db.cursor()

for api in api_list:
	cursor.execute('''INSERT INTO api_list (api_name, api_url) VALUES (%s, %s)''', (api, api_list[api]))
	db.commit()

