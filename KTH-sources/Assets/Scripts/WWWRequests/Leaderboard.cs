
using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Leaderboard : MonoBehaviour {
	
	public string addEntryToLeaderboardURL;
	public string getLeaderboardURL;
	public string getLastScoreURL;
	
	public Rect leaderboardListGUI;
	
	ScoreManager score;
	
	// Use this for initialization
	void Start () {
		
		score = GetComponent<ScoreManager>();
		
		GetLeaderboard();
		
		// TEST
		AddEntryToLeaderboard("TOTO", 99999999);
	}
	
	public delegate void OnServerResponse (string response);
	
	IEnumerator WaitForRequest(WWW www, OnServerResponse Callback)
    {
        yield return www;
 
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
			
			Callback(www.text);
        } else {
            Debug.Log("WWW Error: "+ www.error);
        }    
    }
	
	public void AddEntryToLeaderboard (string name, int score) {
		
		WWWForm form = new WWWForm ();
		
		form.AddField ("name", name);
		form.AddField ("score", score);
		
		WWW www = new WWW(addEntryToLeaderboardURL, form);
        StartCoroutine(WaitForRequest(www, OnAddedEntry));
        
	}
	
	public void GetLeaderboard () {
		
		WWW www = new WWW(getLeaderboardURL);
        StartCoroutine(WaitForRequest(www, ParseLeaderboard));
		
	}
	
	public void GetLastScore () {
		
		WWW www = new WWW(getLastScoreURL);
        StartCoroutine(WaitForRequest(www, ReturnLastScore));
		
	}
	
	
	
	
	void ParseLeaderboard (string response) {
		
		var test = JSON.Parse(response);
		
		int j = 0;
		
		foreach (var i in test.Childs) {
			
			Debug.Log (i["name"].Value+" : "+i["score"].Value);
			
			float x = leaderboardListGUI.x;
			float y = leaderboardListGUI.y + (j*leaderboardListGUI.height);
			float w = leaderboardListGUI.width;
			float h = leaderboardListGUI.height;
			
			GUI.Label(
				new Rect(x, y, w, h)
				,i["name"].Value+" : "+i["score"].Value
			);
			
			j++;
		}
		
	}
	
	void OnAddedEntry (string response) {
		
		Debug.Log ("Entry Added");
		
		// execute le code
	}
	
	void ReturnLastScore (string response) {
		
		score.SendMessage("OnLastScoreRecovered", int.Parse (response));
	}
}