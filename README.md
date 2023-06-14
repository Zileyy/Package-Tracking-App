<h2><strong>Tracking App</strong></h2>
<img src="https://img.shields.io/pypi/status/gspread" align='left'>
<img src="https://img.shields.io/pypi/pyversions/django?label=Python" align='left'>
<br>
<br>
Tracking App is my personal passion project. It is used for tracking packages, updating packages info, updating location and more.

This contains:<br>
Site for clients - using tacking number to see current location of your package.<br>
Desktop Admin App - editing package data.<br>
Python Populate Script - Script that I've made to populate database with dummy data.<br>

<br>
Since it would be very hard for someone to understand this project without my DB sturucture. I whill explain it shortly.

<br>

<h3><strong>Site for clients</strong></h3>
<br>
On our site for clients we are prompted with simply inupt field that takes Tracking Number.
<img src=".imgs/site_first.png">
<br>
<br>
When Tracking number entered we get following information : Cargo type, Tracking Number, Location where it's sent from, Location where it's currently, Location where it's going to be delivered at, date when it's sent, date when it's recieved.

<img src=".imgs/site_tracking.png">

<br>
<br>

<h3><strong>Desktop Admin App</strong></h3>
<br>
In our Admin App we assign EAN-13 barcodes to our packages, we use those EAN-13 codes to indetify and update data of that package in our DB. Which is going to be relfected on website.

We are first presented with simple login.
<br>
<img src=".imgs/admin_app_login.png">
<br>
<br>

When logged in we have three functions.<br>
Check Package - which basically does same as site just checks EAN13 instead of Tacking Number.<br>
Assign EAN 13 - We scan barcode and assign it to the package.<br>
Change Package Info - We change current location of package or any other info.<br>
<br>
<img src=".imgs/admin_app_check.png">
<br>
<img src=".imgs/admin_app_assign.png">

<br>
<br>

<h3><strong>Python Populate Script</strong></h3>
<br>
In python <strong>main.py</strong> script we basically change for loop range to wanted quantity of database entries.
<br>
By calling function from  <strong>util.py</strong> called  <strong>populate()</strong> we generate fresh row of data and write it to our DB.
<br>
DB credentials could be entered in  <strong>database.py</strong>
<br>
<img src=".imgs/py.png">
<br>
<br>
<h3><strong>DB structure</strong></h3>
<br>
Columns in maindb -> tracking (table)
<br>
<img src=".imgs/column_names.png">
<br>
Columns in maindb-> auth (table)
<br>
<img src=".imgs/login_db.png">
<br>
Example of dummy data in tracking table
<br>
<img src=".imgs/dummy_data.png">

<br>
