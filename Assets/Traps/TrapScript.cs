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

	public BossController.Difficulty difficultyTest;

	// Use this for initialization
	void Start () {
		//difficultyTest = GameData.get<BossController.Difficulty> ("difficulty");
		switch (difficultyTest) {
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
		spawnPos.y = 0;
		int i = 0;
		switch (trapType)
		{
		case "bomb":
			spawnPos.y = 0.5f; //Bombs will fall through floor without this
			while (i < Random.Range (1, spawnNum)) {
				Instantiate (bomb, spawnPos, triggerRotation);
				spawnPos.x += Random.Range (-2, 2);
				spawnPos.z += Random.Range (-2, 2);
				i++;
			}
			break;
		case "text":
			spawnPos = triggerPos + triggerDirection * spawnDistance * (Mathf.Min(1.5f,2 / spawnNum));	//Make text spawn further away from trigger on lower difficulties	
			spawnPos.y = 0;
			Instantiate (text, spawnPos, Quaternion.LookRotation(new Vector3(0, -1, 0),new Vector3(0, 1, 0)));
			break;
		case "shroom":
			while (i < Random.Range(1,spawnNum)){
				spawnPos.x += Random.Range (-10, 10);
				spawnPos.z += Random.Range (-10, 10);
				Instantiate (shroom, spawnPos, triggerRotation);
				i++;
			}
			break;
		case "confetti":
			spawnPos.y = 0.5f; //Bombs will fall through floor without this
			while (i < Random.Range(1,spawnNum)){
				Instantiate (confetti, spawnPos, triggerRotation);
				spawnPos.x += Random.Range (-2, 2);
				spawnPos.z += Random.Range (-2, 2);
				i++;
			}
			break;
		case "minion":
			while (i < Random.Range(1,spawnNum)){
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
