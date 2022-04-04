import pyodbc
import os



conn = pyodbc.connect('Driver={SQL Server};'
                      'Server=PetActivityTracker.mssql.somee.com;'
                      'Database=PetActivityTracker;'
                      'Trusted_Connection=yes;')

cursor = conn.cursor()
cursor.execute('SELECT * FROM Users')

for i in cursor:
    print(i)

driver_name = ''
driver_names = [x for x in pyodbc.drivers() if x.endswith(' for SQL Server')]
if driver_names:
    driver_name = driver_names[0]
if driver_name:
    conn_str = 'DRIVER={}; ...'.format(driver_name)
    print(conn_str)
    # then continue with ...
    # pyodbc.connect(conn_str)
    # ... etc.
else:
    print('(No suitable driver found. Cannot connect.)')

#Some other example server values are
server = 'localhost\sqlexpress' # for a named instance
server = 'myserver,port' # to specify an alternate port
server = 'PetActivityTracker.mssql.somee.com' 
database = 'PetActivityTracker' 
username = 'wtotokshau_SQLLogin_1' 
password = 'xfr2k1v5yz' 
cnxn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER='+server+';DATABASE='+database+';UID='+username+';PWD='+ password)
cursor = cnxn.cursor()

#Sample select query
cursor.execute("SELECT * from Users;") 
row = cursor.fetchone() 
while row: 
    print(row[0])
    row = cursor.fetchone()
