using UnityEngine;
using System.Collections;

public class obstacleController : Damageable {

	public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
		explosion.playbackSpeed = 1f;
		explosion.startSize = 3;
		maxHealth = Random.Range (1, 100);
		currentHealth = maxHealth;
		SoundAdapter.playPopSound ();
		Instantiate (explosion, this.gameObject.transform.position, new Quaternion (0, 0, 0, 0));
	}

	public override void takeDamage(int damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			SoundAdapter.playPopSound ();
			Instantiate (explosion, this.gameObject.transform.position, new Quaternion (0, 0, 0, 0));
			Destroy(gameObject);
		}
	}
}
