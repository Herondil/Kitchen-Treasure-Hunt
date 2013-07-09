using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	
	
	public Rect playJungleButton,
				playCavernButton,
				playTempleButton,
				playPyramidButton,
				playTitanicButton,
				leaderboardButton,
				extraButton;
	
	bool drawLeaderBoard,drawExtra;
	
	//Extra
	public Rect resetRect,
				unlockCavern,
				unlockTemple,
				unlockPyramid,
				unlockTitanic;
	
	//Leaderboard
	public Rect leaderboardRect;
	
	//level select
	public int selGridInt = 0;
	public Rect levelSelectRect;
    public string[] selStrings = new string[] {"Jungle", "Cavern", "Temple", "Pyramid", "Titanic"};
	
	//component
	/*
	AssetLoader assetLoader;
	
	void Awake(){
		assetLoader = this.GetComponent<AssetLoader>();
	}
	*/
	
	
	// Use this for initialization
	void Start () {
		drawLeaderBoard = false;
		drawExtra		= false;
		
		GUI.backgroundColor = Color.gray;
	}
	
	void OnGUI(){
		if (GUI.Button(playJungleButton,"Play Jungle"))
			this.GetComponent<SceneManager>().StartRun(levelList.JUNGLE);
		
		if(PlayerPrefs.GetString("HasUnlockedCavern") == "yes"){
			if (GUI.Button(playCavernButton,"Play Cavern"))
				this.GetComponent<SceneManager>().StartRun(levelList.CAVERN);
		}
		
		if(PlayerPrefs.GetString("HasUnlockedTemple") == "yes"){
			if (GUI.Button(playTempleButton,"Play Temple"))
				this.GetComponent<SceneManager>().StartRun(levelList.TEMPLE);
		}
			
		if(PlayerPrefs.GetString("HasUnlockedPyramid") == "yes"){
			if (GUI.Button(playPyramidButton,"Play Pyramid"))
				this.GetComponent<SceneManager>().StartRun(levelList.PYRAMID);
		}
			
		if(PlayerPrefs.GetString("HasUnlockedTitanic") == "yes"){
			if (GUI.Button(playTitanicButton,"Play Titanic"))
				this.GetComponent<SceneManager>().StartRun(levelList.TITANIC);
		}
		
		
		
		if (GUI.Button(leaderboardButton,"Leaderboard"))
            drawLeaderBoard = !drawLeaderBoard;
		if (GUI.Button(extraButton ,"Extra"))
            drawExtra = !drawExtra;
		if(drawLeaderBoard) DrawLeaderBoard();
		if(drawExtra) DrawExtra();
	}
	
	void DrawLeaderBoard(){
		GUI.Label(leaderboardRect,"LeaderBoard");
	}
	
	void DrawExtra(){
		//button reset profile
		if (GUI.Button(resetRect,"Reset Profile"))
			 PlayerPrefs.DeleteAll();
		
		//button unlock level Cavern Temple Pyramid Titanic
		if(PlayerPrefs.GetString("HasUnlockedCavern") == ""){
			if (GUI.Button(unlockCavern,"unlockCavern"))
				PlayerPrefs.SetString("HasUnlockedCavern", "yes");
		}
		
		if(PlayerPrefs.GetString("HasUnlockedTemple") == ""){
			if (GUI.Button(unlockTemple,"unlockTemple"))
				PlayerPrefs.SetString("HasUnlockedTemple", "yes");
		}
			
		if(PlayerPrefs.GetString("HasUnlockedPyramid") == ""){
			if (GUI.Button(unlockPyramid,"unlockPyramid"))
				PlayerPrefs.SetString("HasUnlockedPyramid", "yes");
		}
			
		if(PlayerPrefs.GetString("HasUnlockedTitanic") == ""){
			if (GUI.Button(unlockTitanic,"unlockTitanic")){
				//assetLoader.LoadMap(levelList.TITANIC);
				PlayerPrefs.SetString("HasUnlockedTitanic", "yes");
			}
		}
	}
}
