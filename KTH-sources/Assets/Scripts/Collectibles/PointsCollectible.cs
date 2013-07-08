using UnityEngine;
using System.Collections;

public class PointsCollectible : AbstractCollectible, CollectibleInterface {
	
	public int pointsValue;
	public string family;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnLoot (GameObject player) {
		
		Inventory inventory = player.GetComponent<Inventory>();
		
		inventory.AddPointsCollectible (displayedName, pointsValue, family);
		
		Destroy(gameObject);
	}
}
