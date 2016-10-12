using UnityEngine;
using System.Collections;

public class ddrSystemStartBehaviour : Spawnable {

	public GameObject[] spawners, ddrEnemies;
	public int startTime;

	//Difficulty affects the number of splits
	private int difficulty = 2;

	// Use this for initialization
	void Start () {

		if (GameData.get<BossController.Difficulty>("difficulty") != default(BossController.Difficulty))
		{
			difficulty = (int)GameData.get<BossController.Difficulty>("difficulty");
		}
		print ("difficulty is : " + difficulty);
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime != 0) {
			if (((UIAdapter.getTime () [0] * 60) + UIAdapter.getTime () [1]) - startTime > 15*difficulty) {
				print ("we past 10sec");

				//disable spawners
				foreach (GameObject spawner in spawners) {
					spawner.GetComponent<ddrSpawnerController> ().canShoot = false;
				}

				//destroy all remaining ddr enemies
				ddrEnemies = GameObject.FindGameObjectsWithTag("ddrEnemy");
				foreach (GameObject ddrEnemy in ddrEnemies) {
					Destroy (ddrEnemy);
				}

				//TODO UNLOCK MOVEMENT AND START CUTSCENE

			}
		}
	}

	public override void Spawn(){
		startTime = (UIAdapter.getTime () [0] * 60) + UIAdapter.getTime () [1]; 
		spawners = GameObject.FindGameObjectsWithTag("ddrSpawner");
		foreach (GameObject spawner in spawners) {
			spawner.GetComponent<ddrSpawnerController> ().canShoot = true;
		}
	}
}
