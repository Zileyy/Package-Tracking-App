<?php
//  File that is used for connection to database
$serverName = "DESKTOP-JKO0N2O\\TEST_ONE"; //serverName\instanceName

// The connection will be attempted using Windows Authentication.
$connectionInfo = array( "Database"=>"maindb" , "CharacterSet" => "UTF-8");
$conn = sqlsrv_connect( $serverName, $connectionInfo);


?>