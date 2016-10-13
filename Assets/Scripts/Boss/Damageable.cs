using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
	public int bodyDamage;
	public string damagedBy; //PlayerProjectile
    public bool dead = false;

    void Start() {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider collider){
		print (collider);
		if (collider.gameObject.tag == damagedBy) {
            takeDamage (collider.gameObject.GetComponent<ProjectileController>().damage);
			Destroy (collider.gameObject);
		}
	}

	public virtual void takeDamage(int damage){
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

}
