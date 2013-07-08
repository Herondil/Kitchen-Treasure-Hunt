using UnityEngine;
using System.Collections;

public class Monster : AbstractCollectible, CollectibleInterface {
	
	public int strength;
	public string mazeTag;
	
	GameObject maze,
			   player;
	
	NavMeshAgent navMeshAgent;
	
	// Use this for initialization
	void Start () {
		
		maze = GameObject.FindGameObjectWithTag(mazeTag);
		player = GameObject.FindGameObjectWithTag("Player");
		navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
		navMeshAgent.destination = player.transform.position;
	}
	
	public void OnLoot (GameObject player) {
		
		player.SendMessage("RemoveRandom", strength);
		
		// On téléporte ensuite le monstre plus loin dans le labyrinthe
	}
	
	public void TeleportAway () {
		
		
	}
}
