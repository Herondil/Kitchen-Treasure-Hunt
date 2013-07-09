
using UnityEngine;
using System.Collections;
using LitJson;

public class Leaderboard : MonoBehaviour {
	
	public string addEntryToLeaderboardURL;
	public string getLeaderboardURL;
	public string getLastScoreURL;
	
	public Rect leaderboardListGUI;
	public GUIStyle leaderboardStyle;
	
	string leaderboardResponse = "";
	
	ScoreManager score;
	
	// Use this for initialization
	void Start () {
		
		score = GetComponent<ScoreManager>();
		
		//GetLeaderboard();
		
		// TEST
		//AddEntryToLeaderboard("TOTO", 99999999);
	}
	
	public void DrawGUI() {
		
		if(leaderboardResponse.Length > 0) {
			
			JsonData test = JsonMapper.ToObject(leaderboardResponse);
		
			for(int i = 0; i < test.Count; i++) {
				
				float x = leaderboardListGUI.x;
				float y = leaderboardListGUI.y + (i*leaderboardListGUI.height);
				float w = leaderboardListGUI.width;
				float h = leaderboardListGUI.height;
				
				GUI.Label(
					new Rect(x, y, w, h)
					,test[i]["name"]+" : "+test[i]["score"],
					leaderboardStyle
				);
			}
			//Debug.Log (test);
		}
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
		
		leaderboardResponse = response;
		
	}
	
	void OnAddedEntry (string response) {
		
		Debug.Log ("Entry Added");
		
		this.GetComponent<SceneManager>().ReturnToMenu();
	}
	
	void ReturnLastScore (string response) {
		
		score.SendMessage("OnLastScoreRecovered", int.Parse (response));
	}
}