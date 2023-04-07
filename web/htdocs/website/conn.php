<?php
//  File that is used for connection to database
$serverName = "DESKTOP-6ASKG74\\AJNURPROJECT"; //serverName\instanceName

// The connection will be attempted using Windows Authentication.
$connectionInfo = array( "Database"=>"maindb");
$conn = sqlsrv_connect( $serverName, $connectionInfo);




?>