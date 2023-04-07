<?php
//Include file for database connection
include 'conn.php';

header("content-type: text/html; charset=UTF-8");  

//Tracking number of the package
$tr_num = $_POST['trnumber'];

//Checks if connection is successful
if( $conn === false ) {
    die( print_r( sqlsrv_errors(), true));
}

//Querry for finding package information with given tracking number in database
$sql = "SELECT package_name, sent_location, sent_date , deliver_location, deliver_date, current_location FROM tracking WHERE tracking_number='$tr_num';";
//Execute querry
$stmt = sqlsrv_query( $conn, $sql);
while ($obj = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_BOTH)) {
    $_POST['package_name'] = $obj['package_name'];
    $_POST['sent_location'] = $obj['sent_location'];
    $_POST['sent_date'] = $obj['sent_date']->format('Y/m/d');
    $_POST['deliver_location'] = $obj['deliver_location'];
    $_POST['deliver_date'] = $obj['deliver_date']->format('Y/m/d');
    $_POST['current_location'] = $obj['current_location'];
    $_POST['tracking_number'] = $tr_num;
    
    }
    

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <link rel="stylesheet" href="front.css">
</head>
<body>

<nav class="navbar navbar-expand-xl navbar-dark bg-dark" aria-label="Sixth navbar example">
    <div class="container-fluid">
      <a class="navbar-brand" href="#">Package Tracking</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample06" aria-controls="navbarsExample06" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarsExample06">
        <ul class="navbar-nav me-auto mb-2 mb-xl-0">
          <li class="nav-item">
            <a class="nav-link active" aria-current="page" href="#">Home</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">About us</a>
          </li>
  
        </ul>
        <form role="search">
          <input class="form-control" type="search" placeholder="Search" aria-label="Search">
        </form>
      </div>
    </div>
  </nav>

  <center> <img class='indication-icons' src='img/icons.png'> </center>

  <h5 class='txtHeading'>Cargo type: <?php echo $_POST['package_name']?></h5>
  <h5 class='txtHeading'>Tracking Number: <?php echo $_POST['tracking_number']?></h5>

  <div class="row row-cols-1 row-cols-md-3 mb-3 text-center">
      <div class="col">
        <div class="card mb-4 rounded-3 shadow-sm">
          <div class="card-header py-3">
            <h4 class="my-0 fw-normal">Sent From</h4>
          </div>
          <div class="card-body">
            <ul class="list-unstyled mt-3 mb-4">
            <h4> Location: <?php echo $_POST['sent_location']; ?></h4>
            <h4> Date:  <?php echo $_POST['sent_date'] ?></h4>
            </ul>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card mb-4 rounded-3 shadow-sm">
          <div class="card-header py-3">
            <h4 class="my-0 fw-normal">Current</h4>
          </div>
          <div class="card-body">
            <ul class="list-unstyled mt-3 mb-4">
            <h4> Location: <?php echo $_POST['current_location'] ?></h4>
            <h4> Now </h4>
            </ul>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card mb-4 rounded-3 shadow-sm border-primary">
          <div class="card-header py-3 text-bg-primary border-primary">
            <h4 class="my-0 fw-normal">Deliver</h4>
          </div>
          <div class="card-body">
            <ul class="list-unstyled mt-3 mb-4">
            <h4> Location: <?php echo $_POST['deliver_location'] ?></h4>
            <h4> Date:  <?php echo $_POST['deliver_date'] ?></h4>
            </ul>
            
          </div>
        </div>
      </div>
    </div>

  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>

</body>
</html>