using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {

	public GameObject button;
	public GameObject bomb;
	public string trapType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			spawnTrap (this.gameObject.transform.position);
			Destroy (this.gameObject);
		}
	}
		
	void spawnTrap(Vector3 location){
		switch (trapType)
		{
		case "bomb":
			location.z += 5;
			Instantiate (bomb, location, new Quaternion (0, 0, 0, 0));
			break;
		case "button":
			location.x += 5;
			Instantiate (button, location, new Quaternion (0, 0, 0, 0));
			break;
		default:
			print("Invalid trap");
			break;
		}

	}
}
