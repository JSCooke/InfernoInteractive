using UnityEngine;
using System.Collections;

public class falseBombController : MonoBehaviour {

	public string damagedBy; //PlayerProjectile
	public ParticleSystem explosion;
	private float timer = 3;
	public bool timing = true;

	public bool Timing {
		get {
			return timing;
		}
		set {
			timing = value;
		}
	}
		
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		print (timer);
		if (timer <= 0) {
			explode();
		}
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == damagedBy) {
			explode ();
			Destroy (collider.gameObject);
		}
	}

	void explode(){
		//Play some explosion and some sound.
		Instantiate(explosion,gameObject.transform.position, new Quaternion(0,0,0,0));
		Destroy (this.gameObject);
	}
}