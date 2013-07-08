<?php header('Content-type: application/json');

require './leaderboard.class.php';

$obj = new Leaderboard();

$leaderboard = $obj->fetchFromSaveFile();


echo $leaderboard;