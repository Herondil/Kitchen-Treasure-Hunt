using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public float runTimeLength,
				 endDelay,
				 introDelay;
	
	public Rect  timeRect;
	public GUIStyle timeStyle;
	
	//the asset of the run
	public GameObject  	player,
					  	cube,
					   	mazeGround;
	
	public Texture2D map;
	
	//the instances
	
	float timeElapsed,
		  currentRunTime;
	
	Vector3 playerStartPos;
	
	void OnEnable(){
		timeElapsed    = 0f;
		currentRunTime = runTimeLength;
		GenerateMap();
		GameObject.Instantiate(mazeGround,new Vector3(-1000,0,-1000),Quaternion.identity);
		GameObject.Instantiate(player,playerStartPos,Quaternion.identity);
	}
	
	void GenerateMap(){
		for(int x = 0; x < 100; x++){
			for(int y = 0; y < 100; y++){
				
				
				Color pixColor = map.GetPixel(x,y);
				
				if(pixColor == Color.green){
					playerStartPos = new Vector3(x, 5, y);
				}
				if(pixColor == Color.black){
					Instantiate(this.cube, new Vector3(x, 0, y), Quaternion.identity);
				}
			}
		}
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
	
	
	public void AddTime (float time) {
		
		currentRunTime += time;
	}
}