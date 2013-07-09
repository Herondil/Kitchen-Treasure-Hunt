<?php require './leaderboard.class.php';

$obj = new Leaderboard();

$obj->fetchFromSaveFile(); ?>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>Kitchen Treasure Hunt - Leaderboard</title>
		<style>
		body {
			font-family: Helvetica, Arial, sans-serif;
		}
		h1 {
			text-align: center;
		}
		ul {
			width: 750px;
			margin: auto;
			list-style-type: none;
		}
		ul li {
			overflow: auto;
			padding: 6px 0;
		}
		ul li strong {
			float: right;
		}
		ul li span {
			text-transform: uppercase;
			float: left;
		}
		</style>
	</head>
	<body>
		<h1>Highscores</h1>
		<ul>
		<?php foreach($obj->leaderboard AS $entry) {
			
			echo '<li><span>'.$entry->name.' : </span><strong>'.$entry->score.'</strong></li>';
		}?>
		</ul>
	</body>
</html>