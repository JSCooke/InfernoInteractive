using UnityEngine;
using System.Collections;

public class deathTextController : MonoBehaviour {

	public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
		explosion.playbackSpeed = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player" && collider.gameObject.GetComponent<TankController> () != null) {
			Instantiate (explosion, this.gameObject.transform.position, new Quaternion(0,0,0,0));
			UIAdapter.Idiot = true;
			collider.gameObject.GetComponent<TankController> ().takeDamage(10000);
		}
	}
}
