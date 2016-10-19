using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {

	public GameObject text;
	public GameObject bomb;
	public GameObject shroom;
	public GameObject confetti;
	public GameObject minion;
	public string trapType;
	private int spawnNum;

	private BossController.Difficulty difficulty;

	// Use this for initialization
	void Start () {
		//Set difficulty
		if (GameData.get<BossController.Difficulty> ("difficulty") != default(BossController.Difficulty)) {
			difficulty = GameData.get<BossController.Difficulty> ("difficulty");
			switch (difficulty) {
			case BossController.Difficulty.Easy:
				spawnNum = 1;
				break;
			case BossController.Difficulty.Medium:
				spawnNum = 3;
				break;
			case BossController.Difficulty.Hard:
				spawnNum = 5;
				break;
			}
		} else {
			spawnNum = 1;
		}

	}

	void OnTriggerEnter (Collider other) {
		//Create the trap when the player hits the trigger
		if (other.gameObject.tag == "Player") {
			spawnTrap ();
			Destroy (this.gameObject);
		}
	}
		
	void spawnTrap(){
		//Spawn traps in front of the trigger
		Vector3 triggerPos = this.transform.position;
		Vector3 triggerDirection = this.transform.forward;
		Quaternion triggerRotation = this.transform.rotation;
		float spawnDistance = 15;
		Vector3 spawnPos = triggerPos + triggerDirection*spawnDistance;
		spawnPos.y = 0; //Traps need to spwan on the ground
		int i = 0;
		switch (trapType)
		{
		case "bomb":
			spawnPos.y = 0.5f; //Bombs will fall through floor without this
			while (i < spawnNum) {	//Spawn more based on difficulty
				Instantiate (bomb, spawnPos, triggerRotation);
				spawnPos.x += Random.Range (-2, 2);
				spawnPos.z += Random.Range (-2, 2);
				i++;
			}
			break;
		case "text":
			spawnPos = triggerPos + triggerDirection * spawnDistance * (Mathf.Clamp(2 / spawnNum, 0.5f, 1.5f));	//Make text spawn further away from trigger on lower difficulties	
			spawnPos.y = 0;
			Instantiate (text, spawnPos, Quaternion.LookRotation(new Vector3(0, -1, 0),new Vector3(0, 1, 0)));
			break;
		case "shroom":
			while (i < spawnNum){	//Spawn more based on difficulty
				spawnPos = triggerPos + triggerDirection*spawnDistance*2;
				spawnPos.y = 0;
				if (i % 2 == 0) {	//Prevent mushrooms appearing a long way from thier intended location
					spawnPos.x += Random.Range (i, 10);
					spawnPos.z += Random.Range (i, 10);
				} else {
					spawnPos.x -= Random.Range (0, 10-i);
					spawnPos.z -= Random.Range (0, 10-i);
				}
				Instantiate (shroom, spawnPos, triggerRotation);
				i++;
			}
			break;
		case "confetti":
			spawnPos.y = 0.5f; //Bombs will fall through floor without this
			while (i < spawnNum){	//Spawn more based on difficulty
				Instantiate (confetti, spawnPos, triggerRotation);
				spawnPos.x += Random.Range (-2, 2);
				spawnPos.z += Random.Range (-2, 2);
				i++;
			}
			break;
		case "minion":
			while (i < spawnNum){	//Spawn more based on difficulty
				Instantiate (minion, spawnPos, triggerRotation);
				spawnPos.x += Random.Range (-2, 2);
				spawnPos.z += Random.Range (-2, 2);
				i++;
			}
			break;
		default:
			print("Invalid trap");
			break;
		}

	}
}
