using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ddrSystemStartBehaviour : Spawnable {

	public GameObject[] spawners, ddrEnemies;
	public GameObject tank;
	public DiscoLightController discoLightController;
	public GameObject teleporter;
	public int startTime;

	//Dialogue things
	public TextAsset theText;

	public int startLine = 0;
	public int endLine = 0;
	public DialogTextManager dialogManager;
	public bool destroyWhenActivated = true;
	public bool stopGameMovements;
	public bool shouldSpawn = false;
	public Spawnable spawningObject; 

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

				if (difficulty == 4 && !AchievementController.hasUsedShield) {
					List<string> achievementsToDisplay = new List<string> ();
					AchievementController.updateAchievement ("Who needs a shield", true);
					achievementsToDisplay.Add ("Who needs a shield");
					//cycle through all achievements youved gained
					AchievementController.displayAchievements(achievementsToDisplay);
				}

				//TODO UNLOCK MOVEMENT AND START CUTSCENE
				discoLightController.endDisco();

				tank = GameObject.Find ("Tank");
				tank.GetComponent<TankController>().canMove = true;

				//DIALOGUE SECtiON
				dialogManager.ReloadScript(theText);
				dialogManager.currentLineNumber = startLine;
				dialogManager.endLineNumber = endLine;
				dialogManager.stopGameMovements = stopGameMovements;
				dialogManager.EnableDialogBox();


				if (shouldSpawn == true) {
					dialogManager.shouldSpawn = true;
					dialogManager.spawningObject = spawningObject;
				} else {
					dialogManager.shouldSpawn = false;
				}

				//if end line isnt inputted default to all lines
				if (endLine == 0)
				{
					dialogManager.endLineNumber = dialogManager.textLines.Length - 1;
				}

				if (destroyWhenActivated)
				{
					Destroy(gameObject);
				}

				//DIALOGUE SECtiON


				//spawn teleporter
				teleporter.SetActive(true);
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
