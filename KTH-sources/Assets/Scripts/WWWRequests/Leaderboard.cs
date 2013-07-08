
using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Leaderboard : MonoBehaviour {
	
	public string addEntryToLeaderboardURL;
	public string getLeaderboardURL;
	
	
	// Use this for initialization
	void Start () {
		
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
	
	void AddEntryToLeaderboard (string name, int score) {
		
		WWWForm form = new WWWForm ();
		
		form.AddField ("name", name);
		form.AddField ("score", score);
		
		WWW www = new WWW(addEntryToLeaderboardURL, form);
        StartCoroutine(WaitForRequest(www, OnAddedEntry));
        
	}
	
	void GetLeaderboard () {
		
		WWW www = new WWW(getLeaderboardURL);
        StartCoroutine(WaitForRequest(www, ParseLeaderboard));
		
	}
	
	
	
	
	void ParseLeaderboard (string response) {
		
		var test = JSON.Parse(response);
		
		foreach (var i in test.Childs) {
			
			Debug.Log (i["name"].Value+" : "+i["score"].Value);
		}
		
	}
	
	void OnAddedEntry (string response) {
		
		Debug.Log ("Entry Added");
		
		// execute le code
	}
}