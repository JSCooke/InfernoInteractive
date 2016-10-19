using UnityEngine;
using System.Collections;

public class Fence : Damageable {
	public override void takeDamage(int damage){
		SoundAdapter.playFenceSound();
		currentHealth -= damage;
		if (currentHealth <= 0 && !unkillable) {
			Destroy(gameObject);
		}
	}
}
