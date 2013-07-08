using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	public Rect scoreRect;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.Label(scoreRect,"Score");
	}
}
