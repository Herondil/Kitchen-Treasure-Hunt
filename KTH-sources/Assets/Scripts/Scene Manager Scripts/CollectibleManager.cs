using UnityEngine;
using System.Collections;

public class CollectibleManager : MonoBehaviour {
	
	//the asset of the run
	public GameObject  	exit,
					  	fourchette;
	
	
	public void GenerateCollectible (Color pixColor, int x, int y) {
		
		if(pixColor == Color.red){
			Instantiate(this.exit, new Vector3(x, 0, y), Quaternion.identity);
		}
		
		if(pixColor == Color.cyan){
			Instantiate(this.fourchette, new Vector3(x, 0, y), Quaternion.identity);
		}
	}
	
	
}