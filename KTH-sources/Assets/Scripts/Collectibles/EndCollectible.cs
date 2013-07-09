using UnityEngine;
using System.Collections;

public class EndCollectible : AbstractCollectible, CollectibleInterface {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnLoot (GameObject player) {
		
		// Lancer ici la fin du niveau
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		
		controller.GetComponent<SceneManager>().EndRun();
		
		Destroy(gameObject);
	}
}
