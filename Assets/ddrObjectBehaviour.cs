using UnityEngine;
using System.Collections;

public class ddrObjectBehaviour : Damageable
{

    public float speed;
	public GameObject explosion;
	public GameObject tank;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

	void OnCollisionEnter (Collision collision){

		if (collision.gameObject.tag == "Player") {
			print ("yo Player");
			Instantiate (explosion, transform.position, transform.rotation);
			//Damage Player + shake screen

			tank = GameObject.Find ("Tank");
			TankController temp = tank.GetComponent<TankController> ();
			temp.takeDamage (bodyDamage);
			Destroy (gameObject);
		}

	}

}
