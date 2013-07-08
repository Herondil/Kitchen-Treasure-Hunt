<?php

class Leaderboard {

	private $saveFile = './leaderboard.txt';
	
	private $leaderboard = array();
	
	private $size = 10;
	
	
	public function fetchFromSaveFile() {
		
		$savedData = file_get_contents($this->saveFile);
		
		$this->leaderboard = json_decode($savedData);
		
		return $savedData;
	}
	
	public function saveIntoFile() {
		
		$savedData = json_encode($this->leaderboard);
		
		return file_put_contents($this->saveFile, $savedData);
	}
	
	public function addEntryToLeaderBoard($name, $score) {
		
		$i = 0;
		
		foreach($this->leaderboard AS $entry) {
		
			//var_dump($entry);
			
			if($score > $entry->score) {
				
				$extraEntries = array_slice($this->leaderboard, $i);
				if(count($this->leaderboard) >= $this->size) array_pop($extraEntries);
				array_unshift($extraEntries, array('name' => $name, 'score' => $score));
				
				//var_dump($extraEntries);
				
				array_splice($this->leaderboard, $i);
				
				foreach($extraEntries AS $scoring) {
					
					array_push($this->leaderboard, $scoring);
				}
				
				break;
			}
			elseif($i === count($this->leaderboard) - 1 && $i < $this->size - 1) {
				
				array_push($this->leaderboard, array('name' => $name, 'score' => $score));
			}
			
			$i++;
		}
		
		if(count($this->leaderboard) === 0) {
			
			array_push($this->leaderboard, array('name' => $name, 'score' => $score));
		}
		
		//var_dump($this->leaderboard);
		
		return $this->saveIntoFile();
	}
}