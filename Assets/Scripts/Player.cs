using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

//Adapted from inScope Studios' health bar tutorial
/**
 * A simple player class allowing UI elements to be tested.
 * Also shows how to use the UI Adapter.
 */
public class Player : MonoBehaviour {

	public UIAdapter ui;

	//This is the simplest way to pass sprites into the achievements.
	public Sprite sprite1;
	public Sprite sprite2;

	// Use this for initialization
	void Start () {
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
			ui.achieve ("Completed the tutorial", sprite1);
		} else if (Input.GetKeyDown (KeyCode.LeftCommand)){
			ui.achieve ("Defeated King Slime", sprite2);
		} else if (ui.playerDead ()) {
			ui.die ();
		} else if (ui.bossDead ()) {
			ui.win ();
		}
	}
}
