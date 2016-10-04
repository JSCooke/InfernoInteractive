using UnityEngine;
using System.Collections;

public abstract class Damageable : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
	public int bodyDamage;
	public string damagedBy; //PlayerProjectile
    public bool dead = false;

    void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == damagedBy) {
            takeDamage (collider.gameObject.GetComponent<ProjectileController>().damage);
			Destroy (collider.gameObject);
		}
	}

	public virtual void takeDamage(int damage){}

}
