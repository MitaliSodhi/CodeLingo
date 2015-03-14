import MySQLdb
import json
import urllib2
from datetime import datetime
import time
import requests
import schedule
from time import strftime

db = MySQLdb.connect(host="localhost", user="root", passwd="password", db="dataweave")
cursor = db.cursor()

def time_diff(last_crawl_time):
	now = datetime.now()
	current_time = strftime("%H:%M:%S")
	FMT = '%H:%M:%S'
	tdelta = datetime.strptime(current_time, FMT) - datetime.strptime(last_crawl_time, FMT)
	return str(tdelta).split(':')[1]

def check_health():
	api_list = {}
	cursor.execute('SELECT api_name, api_url from api_list')
	for row in cursor.fetchall():
		api_list[str(row[0]).strip()] = str(row[1]).strip()

	for api in api_list:
		cursor.execute('SELECT crawl_frequency, last_crawl from api_list where api_name=%s', (api));
		for row in cursor.fetchall():
			crawl_frequency = row[0]
			last_crawl = row[1]
		if int(time_diff(last_crawl)) >= int(crawl_frequency):
			start_time = time.time()
			response = requests.get(api_list[api])
			load_time = time.time() - start_time
			content = response.text
			json_content = json.loads(content)
			print api, json_content['status_code'], load_time, time_diff(last_crawl)
			now = datetime.now()
			cursor.execute('''INSERT INTO dw_api_tracking (api_name, crawl_date, crawl_time, status_text, status_code, count, response_time) VALUES (%s, %s, %s, %s, %s, %s, %s)''', (api, str(now).split()[0], strftime("%H:%M:%S"), json_content['status_text'], json_content['status_code'], json_content['count'], load_time))
			db.commit()

			cursor.execute('''UPDATE api_list SET last_crawl=%s WHERE api_name=%s''', (strftime("%H:%M:%S"), api))
			db.commit()

schedule.every(30).seconds.do(check_health)

while True:
	schedule.run_pending()
	time.sleep(1)