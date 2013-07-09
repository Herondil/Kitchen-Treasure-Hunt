using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	public Rect scoreRect, returnRect;
	
	ArrayList familles;
	int points = 0;
	Hashtable familleCompletion;
	
	Leaderboard leaderboard;
	bool displayTestBox;
	string pseudo = "AAA";
	
	// Use this for initialization
	void Start () {
		
		familles = new ArrayList();
		familleCompletion = new Hashtable();
		
		familles.Add (new Famille ("Set de table de Kui-Yere-Daur", 10000, new string[3] {"Fourchette de Kui-Yere-Daur", "Assiette de Kui-Yere-Daur", "Couteau de Kui-Yere-Daur"}));
		familleCompletion["Set de table de Kui-Yere-Daur"] = 0;
		familles.Add (new Famille ("Poêles jumelles légendaires", 12000, new string[2] {"Poêle à frire de Raie-Ponsse", "Poêle à crèpes de Shande L'Heure"}));
		familleCompletion["Poêles jumelles légendaires"] = 0;
		
		leaderboard = GetComponent<Leaderboard>();
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		CalculateTotalPoints(player.GetComponent<Inventory>());
		
		displayTestBox = false;
		
		// On récupère les infos
		leaderboard.GetLastScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		
		GUI.Label(scoreRect,"Score : "+points);
		
		if(displayTestBox) {
			
			pseudo = GUI.TextField(new Rect(300, 300, 200, 30), pseudo, 7);
			if(GUI.Button(new Rect(300, 340, 200, 30), "Envoyer son score")) {
				
				leaderboard.AddEntryToLeaderboard(pseudo, points);
			}
		}
		else {
			
			if (GUI.Button(returnRect,"Back")){
				this.GetComponent<SceneManager>().ReturnToMenu();
			}
		}
		
	}
	
	public int CalculateTotalPoints (Inventory inventory) {
		
		ArrayList items = inventory.GetInventory();
		
		points = 0;
		
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
		
		// Temps restant
		float time = GetComponent<GameManager>().GetRunTime();
		
		points += Mathf.RoundToInt(time * 500);
		
		
		return points;
	}
	
	public void OnLastScoreRecovered (int score) {
		
		if(score <= points) {
			
			displayTestBox = true;
		}
	}
}
