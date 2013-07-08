using UnityEngine;
using System.Collections;

public class ShieldCollectible : AbstractCollectible, CollectibleInterface {
	
	public int strength;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnLoot (GameObject player) {
		
		Inventory inventory = player.GetComponent<Inventory>();
		
		inventory.shield += strength;
		
		Debug.Log (inventory.shield);
		
		Destroy(gameObject);
	}
}
