using UnityEngine;
using System.Collections;

public abstract class AbstractCollectible : MonoBehaviour {
	
	public string displayedName;
	
	void OnTriggerEnter (Collider other) {
		
		if (other.tag == "Player") {
			
			other.SendMessage("OnLoot", other.gameObject);
		}
	}
}
