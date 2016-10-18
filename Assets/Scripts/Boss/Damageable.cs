using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;
	public int bodyDamage;
	public string damagedBy; //PlayerProjectile
    public bool dead = false;
    public bool unkillable;

    void Start() {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == damagedBy) {
            takeDamage (collider.gameObject.GetComponent<ProjectileController>().damage);
			Destroy (collider.gameObject);
		}
	}

	public virtual void takeDamage(float damage){
        currentHealth -= damage;
        if (currentHealth <= 0 && !unkillable) {
            Destroy(gameObject);
        }
    }

}
