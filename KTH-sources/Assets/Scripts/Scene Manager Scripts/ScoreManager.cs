using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	public Rect scoreRect;
	
	ArrayList familles;
	int points = 0;
	Hashtable familleCompletion;
	
	// Use this for initialization
	void Start () {
		
		familles.Add (new Famille ("Set de table de Kui-Yere-Daur", 10000, new string[3] {"Fourchette de Kui-Yere-Daur", "Assiette de Kui-Yere-Daur", "Couteau de Kui-Yere-Daur"}));
		familleCompletion["Set de table de Kui-Yere-Daur"] = 0;
		familles.Add (new Famille ("Poêles jumelles légendaires", 12000, new string[2] {"Poêle à frire de Raie-Ponsse", "Poêle à crèpes de Shande L'Heure"}));
		familleCompletion["Poêles jumelles légendaires"] = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.Label(scoreRect,"Score");
	}
	
	public int CalculateTotalPoints (Inventory inventory) {
		
		ArrayList items = inventory.GetInventory();
		
		for(int i = 0; i < items.Count; i++) {
			
			GatheredItem item = (GatheredItem) items[i];
			
			points += item.points;
			
			foreach(Famille fam in familles) {
				
				if(fam.CheckIfFromFamille(item.name)) {
					
					int completion = (int) familleCompletion[fam.familleName];
					familleCompletion[fam.familleName] = completion + 1;
				}
				if((int) familleCompletion[fam.familleName] == fam.members.GetLength(0)) {
					
					points += fam.bonusPoints;
				}
			}
		}
		
		
		return points;
	}
}
