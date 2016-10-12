using UnityEngine;
using System.Collections;

public class DeathTextScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player" && collider.gameObject.GetComponent<TankController> () != null) {
			UIAdapter.Idiot = true;
			collider.gameObject.GetComponent<TankController> ().takeDamage(10000);
		}
	}
}
