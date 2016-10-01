using UnityEngine;
using System.Collections;
using System;
//Adapted from inScope Studios' health bar tutorial
//This demonstrates the code  on the player's side.
public class Player : MonoBehaviour {

	public Stat health;
	public Stat boss;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			health.damage(-10);
		} else if (Input.GetKeyDown (KeyCode.S)) {
			health.damage(10);
		} else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			boss.damage (-1);
		} else if (Input.GetKeyDown(KeyCode.DownArrow)){
			boss.damage (1);
		}

	}

}
