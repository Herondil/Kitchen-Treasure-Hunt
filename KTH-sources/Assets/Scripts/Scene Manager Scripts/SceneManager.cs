using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public GameManager  gameScript;
	public MenuManager  menuScript;
	public ScoreManager scoreScript;
	
	void Awake(){
		gameScript.enabled  = false;
		menuScript.enabled  = false;
		scoreScript.enabled = false;
	}
	
	void Start () {
		menuScript.enabled = true;
	}
	
	/// <summary>
	/// Starts the run.
	/// </summary>
	public void StartRun(){
		menuScript.enabled = false;
		gameScript.enabled = true;
	}
	
	/// <summary>
	/// Ends the run.
	/// </summary>
	public void EndRun(){
		gameScript.enabled  = false;
		scoreScript.enabled = true;
		
		GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMotor>().canControl = false;
		GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>().enabled = false;
	}
}
