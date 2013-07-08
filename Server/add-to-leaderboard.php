<?php header('Content-type: application/json');

require './leaderboard.class.php';

$obj = new Leaderboard();

$obj->fetchFromSaveFile();

if($_POST && $_POST['name'] && $_POST['score']) {
	
	$obj->addEntryToLeaderBoard($_POST['name'], $_POST['score']);
}
