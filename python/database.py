#File used of communicating with database 
#IMPORTS
import pyodbc 

#Connecting do MsSql DB with windows auth
cnxn = pyodbc.connect("Driver={SQL Server};"
                      "Server=DESKTOP-6ASKG74\AJNURPROJECT;"
                      "Database=maindb;"
                      "Trusted_Connection=yes;")

cursor = cnxn.cursor()





    

    