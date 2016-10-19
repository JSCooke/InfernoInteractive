using UnityEngine;
using System.Collections;

public class ddrObjectBehaviour : MonoBehaviour
{

    public float speed;
	public GameObject explosion;
	public GameObject tank;
	public int maxHealth;
	public int currentHealth;
	public int bodyDamage;
	public string damagedBy; //PlayerProjectile

	void Start() {
		currentHealth = maxHealth;
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

	void OnTriggerEnter(Collider other){

		print ("in here");

		if (other.GetComponent<Collider>().gameObject.tag == damagedBy) {
			
			takeDamage (other.GetComponent<Collider>().gameObject.GetComponent<ProjectileController>().damage);
			Destroy (other.GetComponent<Collider>().gameObject);
		}
			
		if (other.gameObject.tag == "Player") {

			//Damage Player + shake screen
			tank = GameObject.Find ("Tank");
			TankController temp = tank.GetComponent<TankController> ();
			temp.takeDamage (bodyDamage);
			Destroy (gameObject); 
		}

	}

	public virtual void takeDamage(int damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Destroy(gameObject);
		}
	}

	void OnDestroy(){
		Instantiate (explosion, transform.position, transform.rotation);
	}

}
