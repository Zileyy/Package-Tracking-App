#IMPORTS
import pandas as pd
import random as rnd
import database as db
import random
from datetime import date, timedelta,datetime

#FUNCTIONS
#Function that returns random airport from airports.csv
def get_airport():
    #Reads airports.csv
    df = pd.read_csv('datasets/airports.csv', encoding='ISO-8859-1')

    #Length of dataframe that we use for max when generating random airports
    rng_max = len(df['Name']) 

    #Generating sent, current, final location of the package written as from_loc, curr_loc, to_loc
    from_loc = df['Name'][rnd.randrange(0,rng_max-1)]
    to_loc = df['Name'][rnd.randrange(0,rng_max-1)]
    curr_loc = df['Name'][rnd.randrange(0,rng_max-1)]

    #Checking and generating new airport again if airport sent is same as the airport package needs to be
    while from_loc == to_loc:
        to_loc = df['Name'][rnd.randrange(0,rng_max-1)]
    
    #Return
    return from_loc, to_loc , curr_loc

#Functions that generates Tracking Number for package (format: TR123AB321)
def generate_trnumber():

    #List of uppercase letters that we can use in tracking number
    ascii_uppercase = list('ABCDEFGHIJKLMNOPQRSTUVWXYZ')
   
    #Every tracking number will start with 'TR' so we assign 'TR' at the start
    trnum = 'TR'

    #Generates 3 random numbers for tracking number
    for x in range(0,3):
        trnum = trnum + str(rnd.randint(0,9))
    
    #Generates 2 random letters 
    trnum = trnum+ascii_uppercase[rnd.randrange(0,len(ascii_uppercase))]
    trnum = trnum+ascii_uppercase[rnd.randrange(0,len(ascii_uppercase))]

    #Generates 3 random numbers for tracking number
    for x in range(0,3):
        trnum = trnum + str(rnd.randint(0,9))

    #Returns generated tracking number as string
    return trnum

#Function that return boolean if value you provided is duplicate in selected column
def db_duplicate_check(local_var , db_column_name):

    #Checking in Tracking table if provided variable is present in provided column (DB)
    try:
        db.cursor.execute(f'SELECT * FROM Tracking WHERE {db_column_name} = \'{local_var}\'; ')
    except: pass

    #List that is going to populated if variable is present in wanted column
    values = []

    #Append variables if they exist
    try:
        for row in db.cursor:
            values.append(row)
    except: pass
    
    #Check if variable is present in wanted column and return bool that indicates status
    if not values : isDuplicate = False
    else: isDuplicate = True

    #Return indicator if var is duplicate in column as bool
    return isDuplicate


#Function that returns random cargo type for package (package_name in db)
def generate_cargo():
    cargo_types = ['Electronics', 'Food products', 'Chemicals', 'Automobile parts', 'Furniture', 'Clothing', 'Medical equipment', 'Industrial machinery', 'Raw materials', 'Perishables', 'Textiles', 'Pharmaceuticals', 'Toys', 'Sporting equipment', 'Books', 'Artwork', 'Jewelry', 'Household appliances', 'Petroleum products', 'Building materials']
    return random.choice(cargo_types)

#Function that returns two dates (sent_date) (deliver_date)
def generate_dates():
    #Initializing dates ranges
    test_date1, test_date2 = date(2023,1,1), date(2024,1,1)
    while test_date2 < date.today() and test_date1 > date.today(): test_date1, test_date2 = date(2023,1,1), date(2024,1,1)

    res_dates = [test_date1]
    
    #Loop to get each date till end date
    while test_date1 != test_date2:
        test_date1 += timedelta(days=1)
        res_dates.append(test_date1)

    #Getting random date from chosen range
    sent_date = random.choice(res_dates)
    deliver_date = random.choice(res_dates)

    #Restricting that sent date could be after deliver date
    while sent_date>deliver_date:
        deliver_date = random.choice(res_dates)

    #Return
    return sent_date, deliver_date

#Function that generates ean-13 code for package
def generate_ean():
    #Generate first 12 digits
    code = ''.join([str(random.randint(0, 9)) for _ in range(12)])
    
    #Calculate check digit
    check_sum = sum(int(d) * (3 if i % 2 == 0 else 1) for i, d in enumerate(code))
    check_digit = (10 - (check_sum % 10)) % 10
    
    #Add check digit to code
    code += str(check_digit)
    
    #Return EAN-13 code as string
    return code

#Function that populates database with generated info (one row)
def populate():

    #Generate info
    package_name = generate_cargo()
    sent_date, deliver_date = generate_dates()
    sent_location, deliver_location, current_location = get_airport()
    tracking_number = generate_trnumber()
    ean = generate_ean()

    #Generate different values if duplicates for tracking_number and ean13
    while db_duplicate_check('tracking_number', tracking_number) == True:  tracking_number = generate_trnumber() 
    while db_duplicate_check('ean13', ean) == True:  ean = generate_ean() 

    #Querry for writing to database
    db.cursor.execute("""
                    INSERT INTO tracking (package_name, tracking_number, sent_date, deliver_date,sent_location, deliver_location, current_location, ean13)
                    VALUES (\'{}\',\'{}\',\'{}\',\'{}\',\'{}\',\'{}\',\'{}\',\'{}\');
                      """.format(package_name, tracking_number, sent_date, deliver_date,sent_location, deliver_location,current_location,ean))

    #Executing querry and writig info to db
    db.cnxn.commit()


