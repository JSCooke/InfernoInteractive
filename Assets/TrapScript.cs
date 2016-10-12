using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {

	public GameObject bomb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			Vector3 bombLocation = this.gameObject.transform.position;
			bombLocation.z += 5;
			spawnBomb (bombLocation);
			Destroy (this.gameObject);
		}
	}

	//Requires that a bomb is somewhere on the map, and clones it.
	void spawnBomb(Vector3 location){
		Instantiate (bomb, location, new Quaternion (0, 0, 0, 0));
	}
}
