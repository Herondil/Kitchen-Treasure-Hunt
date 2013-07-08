using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	
	
	public Rect playButton,leaderboardButton,extraButton;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		if (GUI.Button(playButton,"Play"))
			this.GetComponent<SceneManager>().StartRun();
		if (GUI.Button(leaderboardButton,"Leaderboard"))
            Debug.Log("Clicked the button with text");
		if (GUI.Button(extraButton ,"Extra"))
            Debug.Log("Clicked the button with text");
	}
}
