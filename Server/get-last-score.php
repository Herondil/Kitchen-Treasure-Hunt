<?php header('Content-type: application/json');

require './leaderboard.class.php';

$obj = new Leaderboard();

$obj->fetchFromSaveFile();

if(count($obj->leaderboard) < $obj->size) {
	
	echo "0";
}
else {
	
	echo $obj->leaderboard[count($obj->leaderboard) - 1]->score;
}
