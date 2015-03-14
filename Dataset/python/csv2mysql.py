import csv
import MySQLdb

db = MySQLdb.connect(host="localhost", user="root", passwd="", db="ifsc")
cursor = db.cursor()

with open('ifsc4.csv', 'rU') as csv_file:
	reader = csv.reader(csv_file, delimiter=',', quotechar='"')
	for row in reader:
		cursor.execute('''INSERT INTO ifsc_db (Bank_Name, IFSC_Code, MICR_Code, Branch_Name, Address, Contact, City, District, State) VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s)''', (row[0].strip(), row[1].strip(), row[2].strip(), row[3].strip(), row[4].strip(), row[5].strip(), row[6].strip(), row[7].strip(), row[8].strip()))
		db.commit()