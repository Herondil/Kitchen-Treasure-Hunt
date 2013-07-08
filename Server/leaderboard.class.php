<?php

class Leaderboard {

	private $saveFile = './leaderboard.txt';
	
	private $leaderboard = array();
	
	private $size = 10;
	
	
	public function fetchFromSaveFile() {
		
		$savedData = file_get_contents($this->saveFile);
		
		return $savedData;
	}
	
	public function saveIntoFile() {
		
		$savedData = json_encode($this->leaderboard);
		
		return file_put_contents($this->saveFile, $savedData);
	}
	
	public function addEntryToLeaderBoard($name, $score) {
		
		$i = 0;
		
		if(
		
		foreach($this->leaderboard AS $entry) {
			
			if($score > $entry->score) {
				
				$extraEntries = array_slice($this->leaderboard, $i);
				if(count($this->leaderboard) >= $this->size) array_pop($extraEntries);
				$extraEntries = array_unshift($extraEntries, array('name' => $name, 'score' => $score));
				$this->leaderboard = array_splice($this->leaderboard, $i, count($extraEntries), $extraEntries);
				
				break;
			}
			
			$i++;
		}
		
		return $this->saveIntoFile();
	}
}