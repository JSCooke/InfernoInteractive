using UnityEngine;
using System.Collections;

public abstract class Damageable : MonoBehaviour {

	public int maxHealth, currentHealth;
	public int damage;
	//public GameObject damageText;
	public string damagedBy;

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == damagedBy) {
			takeDamage (collider.gameObject.GetComponent<ProjectileController>().damage);
			Destroy (collider);
		}
	}

	public void takeDamage(int damage){
		currentHealth = currentHealth - damage;
        print(currentHealth);
		//Instantiate(damageText)
	}
}
