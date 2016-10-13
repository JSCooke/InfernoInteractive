using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {

	public GameObject text;
	public GameObject bomb;
	public GameObject shroom;
	public GameObject confetti;
	public string trapType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			spawnTrap ();
			Destroy (this.gameObject);
		}
	}
		
	void spawnTrap(){
		Vector3 triggerPos = this.transform.position;
		Vector3 triggerDirection = this.transform.forward;
		Quaternion triggerRotation = this.transform.rotation;
		float spawnDistance = 10;
		Vector3 spawnPos = triggerPos + triggerDirection*spawnDistance;

		switch (trapType)
		{
		case "bomb":
			Instantiate (bomb, spawnPos, triggerRotation);
			break;
		case "text":
			spawnPos.y = 0;//Text should appear on the ground
			Instantiate (text, spawnPos, Quaternion.LookRotation(new Vector3(0, -1, 0),new Vector3(0, 1, 0)));
			break;
		case "shroom":
			spawnPos.y = 0;
			int i = 0;
			while (i < Random.Range(1,4)){
				spawnPos.x += Random.Range (-10, 10);
				spawnPos.z += Random.Range (-10, 10);
				Instantiate (shroom, spawnPos, triggerRotation);
				i++;
			}
			break;
		case "confetti":
			Instantiate (confetti, spawnPos, triggerRotation);
			break;
		default:
			print("Invalid trap");
			break;
		}

	}
}
