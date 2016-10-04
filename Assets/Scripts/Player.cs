using UnityEngine;
using System.Collections;
using System;
//Adapted from inScope Studios' health bar tutorial
//This demonstrates the code  on the player's side.
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public UIAdapter ui;

	public Sprite sprite1;
	public Sprite sprite2;
	// Use this for initialization
	void Start () {
	}

	public void Awake(){
		//THIS CODE IS TEMPORARY - Assign some values to the achievement dictionary
		ui.achievements = new Dictionary<int, Achievement>{
			{0, new Achievement("Complete the tutorial!", sprite1)},
			{1, new Achievement("Beat the king slime!", sprite2)}
		};
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			ui.damagePlayer (-10);
		} else if (Input.GetKeyDown (KeyCode.S)) {
			ui.damagePlayer (10);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			ui.damageBoss (-10);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			ui.damageBoss (10);
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			ui.achieve (0);
		} else if (Input.GetKeyDown (KeyCode.LeftCommand)){
			ui.achieve (1);
		} else if (ui.playerDead ()) {
			ui.die ();
		} else if (ui.bossDead ()) {
			ui.win ();
		}
	}
}
