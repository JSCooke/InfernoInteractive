﻿using UnityEngine;
using System.Collections;

public class MazeUnitBehaviour : MonoBehaviour {

	//Properties the maze unit can have
	public bool box;
	public bool hole;
	public bool enemies;

	// Use this for initialization
	void Start () {
		if (box) { createBox(); }
		if (hole) { createHole(); }
		if (enemies) { spawnEnemies(); }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void createBox()
	{
		//Load box prefab in middle of maze unit
		GameObject box = (GameObject)Instantiate(Resources.Load("Box"));
		box.transform.parent = transform;
		box.transform.localPosition = new Vector3(0f,3.5f,0f);
	}

	private void createHole()
	{
		//Load hole prefab in middle of maze unit
		transform.Find("Floor").gameObject.SetActive(false);
		GameObject hole = (GameObject)Instantiate(Resources.Load("Hole"));
		hole.transform.parent = transform;
		hole.transform.localPosition = new Vector3(0f, 0f, 0f);
	}

	private void spawnEnemies()
	{
		//Spawn 2 enemies inside maze unit
		GameObject enemyPrefab = (GameObject)(Resources.Load("Alien"));
		GameObject enemy1 = Instantiate(enemyPrefab);
		enemy1.transform.parent = transform;
		enemy1.transform.localPosition = new Vector3(3f, 0f, 0f);

		GameObject enemy2 = Instantiate(enemyPrefab);
		enemy2.transform.parent = transform;
		enemy2.transform.localPosition = new Vector3(-3f, 0f, 0f);
	}
}
