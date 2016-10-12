using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {

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
			Vector3 trapLocation = this.gameObject.transform.position;
			trapLocation.z += 5;
			spawnTrap (trapLocation);
			Destroy (this.gameObject);
		}
	}
		
	void spawnTrap(Vector3 location){
		switch (trapType)
		{
		case "bomb":
			Instantiate (bomb, location, new Quaternion (0, 0, 0, 0));
			break;
		default:
			print("Invalid trap");
			break;
		}

	}
}
