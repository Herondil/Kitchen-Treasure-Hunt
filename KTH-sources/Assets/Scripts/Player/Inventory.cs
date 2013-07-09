using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	
	public int shield;
	
	ArrayList inventory;
	
	// Use this for initialization
	void Start () {
		
		inventory = new ArrayList();
		
		// TESTS
		//inventory.Add (new GatheredItem("Fourchette de Kui-Yere-Daur", "Set de table de Kui-Yere-Daur", 1000));
		//inventory.Add (new GatheredItem("Assiette de Kui-Yere-Daur", "Set de table de Kui-Yere-Daur", 3000));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddPointsCollectible (string displayName, int points, string family) {
		
		GatheredItem item = new GatheredItem(displayName, family, points);
		
		inventory.Add(item);
	}
	
	public void RemoveRandom (int strength) {
		
		// Si on a un bouclier sur soi, le bouclier est consommé
		if(shield > 0 && shield >= strength) {
			
			shield -= strength;
			
			return;
		}
		if(shield > 0 && shield < strength) {
			
			strength -= shield;
			shield = 0;
			
		}
		
		if(inventory.Count > 0) {
			while (strength > 0) {
				
				int index = Random.Range(0, inventory.Count - 1);
			
				inventory.RemoveAt(index);
				
				strength--;
			}
		}
		
		Debug.Log(inventory.Count);
		
	}
	
	public ArrayList GetInventory() {
		
		return inventory;
	}
}
