using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		print ("Triggered");
		if (other.gameObject.tag == "Player") {
			bombController.spawnBomb (this.gameObject.transform.position);
		}
	}
}
