using UnityEngine;
using System.Collections;

public abstract class Damageable : MonoBehaviour {

    public int maxHealth, currentHealth;
	public int bodyDamage;
	public string damagedBy; //PlayerProjectile
    public bool dead = false;

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == damagedBy) {
            takeDamage (collider.gameObject.GetComponent<ProjectileController>().damage);
			Destroy (collider.gameObject);
		}
	}

	public void takeDamage(int damage){

        currentHealth = currentHealth - damage;

        if (currentHealth <= 0) {
            dead = true;  
        }

	}

}
