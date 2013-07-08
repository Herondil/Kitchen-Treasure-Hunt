using UnityEngine;
using System.Collections;

public abstract class AbstractCollectible : MonoBehaviour {
	
	public string displayedName;
	
	void OnTriggerEnter (Collider other) {
		
		Debug.Log (other.tag);
		
		if (other.tag == "Player") {
			
			SendMessage("OnLoot", other.gameObject);
		}
	}
}
