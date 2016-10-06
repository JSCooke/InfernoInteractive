using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
	public int bodyDamage;
	public string damagedBy; //PlayerProjectile
    public bool dead = false;

	private float lastDamageTime = 0;
	private Animator animator;

	void Start() {
        currentHealth = maxHealth;
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if ((animator != null) && (Time.fixedTime - lastDamageTime > 0.5))
		{
			animator.SetBool("isBlink", false);
		}
	}

    void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == damagedBy) {
            takeDamage (collider.gameObject.GetComponent<ProjectileController>().damage);
			Destroy (collider.gameObject);
		}
	}

	public virtual void takeDamage(int damage){
		lastDamageTime = Time.fixedTime;
		if (animator != null)
		{
			animator.SetBool("isBlink", true);
		}

		currentHealth -= damage;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

}
