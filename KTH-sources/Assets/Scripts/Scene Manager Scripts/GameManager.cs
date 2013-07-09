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
	
	public Texture2D jungleMap;
	
	Texture2D map;
	
	//the instances
	
	float timeElapsed,
		  currentRunTime;
	
	Vector3 playerStartPos;
	
	
	AssetLoader assetLoader;
	
	void Awake(){
		assetLoader = this.GetComponent<AssetLoader>();
	}
	
	
	/// <summary>
	/// Starts the jungleMap.
	/// </summary>
	public void StartMap(levelList index){
		///load good jungleMap
		
		
		/*
		assetLoader.LoadMap(index,  () => { 
			//wait = false;
			
			Debug.Log("load ok");
			
			switch(index){
				case levelList.TITANIC:{
				
					if(GameObject.Find("Titanic(Clone)")){
						Debug.Log("Object found");
						//this.map = GameObject.Find("Titanic(Clone)").GetComponent<TerrainData>().map;
					}else{
						Debug.Log("Object not found");
					}
					this.map = GameObject.Find("Titanic(Clone)").GetComponent<TerrainData>().map;
					break;
				}
				case levelList.JUNGLE:{
					//default map
					this.map = jungleMap;
					break;
				}
			}
			
			//this.enabled = true;
		});
		*/
		
		
		
		
		
		switch(index){
			case levelList.TITANIC:{
			
				if(GameObject.Find("Titanic(Clone)").GetComponent<TerrainDataCustom>()){
					Debug.Log("Object found");
				}else{
					Debug.Log("Object not found");
				}
					this.map = GameObject.Find("Titanic(Clone)").GetComponent<TerrainDataCustom>().map;
				break;
			}
			case levelList.JUNGLE:{
				//default map
				this.map = jungleMap;
				break;
			}
		}
		
		this.enabled = true;
		
	}
	
	void OnEnable(){
		timeElapsed    = 0f;
		currentRunTime = runTimeLength;
		GenerateMap();
		GameObject.Instantiate(mazeGround,new Vector3(-1000,0,-1000),Quaternion.identity);
		GameObject.Instantiate(player,playerStartPos,Quaternion.identity);
	}
	
	void GenerateMap(){
		Debug.Log("generation start");
		for(int x = 0; x < 100; x++){
			for(int y = 0; y < 100; y++){
				
				Color pixColor = map.GetPixel(x,y);
				//Debug.Log("pix spoted r "+pixColor.r);
				
				if(pixColor == Color.green){
					playerStartPos = new Vector3(x, 1, y);
					Debug.Log("find start pos");	
				}
				if(pixColor == Color.black){
					Instantiate(this.cube, new Vector3(x, 0, y), Quaternion.identity);
				}
				
				// On fait l'instanciation des collectibles
				GetComponent<CollectibleManager>().GenerateCollectible(pixColor, x, y);
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