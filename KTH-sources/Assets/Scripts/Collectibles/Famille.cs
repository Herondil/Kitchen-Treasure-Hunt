using UnityEngine;
using System.Collections;

public class Famille {

	public string familleName;
	public int bonusPoints;
	public string[] members;
	
	public Famille (string name, int points, string[] members) {
		
		this.familleName = name;
		this.bonusPoints = points;
		this.members = members;
	}
	
	public bool CheckIfFromFamille (string itemName) {
		
		for(int i = 0; i < members.GetLength(0); i++) {
			
			if(itemName == members[i]) {
				
				
				return true;
			} 
		}
		
		return false;
	}
}
