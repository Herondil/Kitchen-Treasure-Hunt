using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public float runTimeLength,
				 endDelay,
				 introDelay;
	
	public Rect  timeRect;
	public GUIStyle timeStyle;
	
	float timeElapsed,
		  currentRunTime;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable(){
		timeElapsed    = 0f;
		currentRunTime = runTimeLength;
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed > (runTimeLength + introDelay )){
			if(timeElapsed > (runTimeLength + endDelay + introDelay)){
				//end of round
			this.GetComponent<SceneManager>().EndRun();
			}
		}else{
			if(timeElapsed > introDelay){
				currentRunTime -= Time.deltaTime;
			}
		}
	}
	
	void OnGUI(){
		GUI.Label(timeRect,"Time left : "+ currentRunTime.ToString("0.0"),timeStyle);
	}
}