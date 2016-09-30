using UnityEngine;
using System.Collections;
using System;
//Adapted from inScope Studios' health bar tutorial
public class Player : MonoBehaviour {

	public Stat health;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			health.CurrentVal += 10;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			health.CurrentVal -= 10;
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			health.ObjectiveCount += 1;
		}
	}

//	float Damage(float damage) {
//		health.CurrentVal -= damage;
//	}

}
