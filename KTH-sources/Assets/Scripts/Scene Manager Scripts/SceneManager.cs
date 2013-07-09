using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public GameManager  gameScript;
	public MenuManager  menuScript;
	public ScoreManager scoreScript;
	
	AssetLoader assetLoader;
	
	void Awake(){
		gameScript.enabled  = false;
		menuScript.enabled  = false;
		scoreScript.enabled = false;
		assetLoader = this.GetComponent<AssetLoader>();
	}
	
	void Start () {
		menuScript.enabled = true;
	}
	
	/// <summary>
	/// Starts the run.
	/// </summary>
	public void StartRun(levelList levelIndex){
		menuScript.enabled = false;
		gameScript.StartMap(levelIndex);
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
	
	
	
	public void ReturnToMenu(){
		/*
		menuScript.enabled  = true;
		scoreScript.enabled = false;
		*/
		assetLoader.Unload();
		Application.LoadLevel(Application.loadedLevel);
	}
}
