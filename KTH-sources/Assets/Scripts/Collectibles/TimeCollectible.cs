using UnityEngine;
using System.Collections;

public class TimeCollectible : AbstractCollectible, CollectibleInterface {
	
	public float timeToAdd;
	public string sceneManagerTag;
	
	GameObject MainSceneManager;
	
	// Use this for initialization
	void Start () {
		
		MainSceneManager = GameObject.FindGameObjectWithTag(sceneManagerTag);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnLoot (GameObject player) {
		
		MainSceneManager.SendMessage("AddTime", timeToAdd);
		
		Destroy(gameObject);
	}
}
