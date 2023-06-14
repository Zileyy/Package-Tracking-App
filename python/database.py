#File used of communicating with database 
#IMPORTS
import pyodbc 

#Connecting do MsSql DB with windows auth
cnxn = pyodbc.connect("Driver={SQL Server};"
                      "Server=WINAUTH_NAME;"
                      "Database=DB_NAME;"
                      "Trusted_Connection=yes;")

cursor = cnxn.cursor()





    

    