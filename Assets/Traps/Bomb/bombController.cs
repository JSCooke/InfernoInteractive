using UnityEngine;
using System.Collections;

public class bombController : MonoBehaviour {

	public string damagedBy; //PlayerProjectile
	public TankController tank;
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
		//Play some explosion and some sound and hurt the player
		Instantiate(explosion,gameObject.transform.position, new Quaternion(0,0,0,0));
		Collider[] inRange = Physics.OverlapSphere (gameObject.transform.position, 10f);
		//This goes through walls - call it a design feature; trees don't stop bombs.
		int i = 0;
		while (i<inRange.Length){
			if (inRange [i].gameObject.tag == "Player") {
				tank = inRange [i].gameObject.GetComponent<TankController> ();
				if (tank != null) {
					tank.takeDamage (50);
				}
			}
			i = i + 1;
		}
		Destroy (this.gameObject);
	}
}