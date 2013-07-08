using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public GameManager  gameScript;
	public MenuManager  menuScript;
	public ScoreManager scoreScript;
	
	void Start () {
		gameScript.enabled  = false;
		menuScript.enabled  = false;
		scoreScript.enabled = false;
	}
	
	void Update () {
	
	}
}
