﻿using UnityEngine;
using System.Collections;

public class forestGuardScript : Damageable {

	public ParticleSystem explosion;
	public Animator guardAnimator;
	public GameObject player;
	int MoveSpeed = 4;
	int MaxDist = 8;
	int MinDist = 6;
	private bool backpedal = false;

	void Start () 
	{
		player = GameObject.Find ("Tank");
		explosion.playbackSpeed = 1f;
		maxHealth = 50;
		currentHealth = maxHealth;
		damagedBy = "PlayerProjectile";
		SoundAdapter.playMinionSound ();
	}

	void Update () 
	{
		if (backpedal) {	//Move away from the player if too close - stops them getting stuck above/below the tank
			transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
			Vector3 transPos = transform.position + transform.forward*MoveSpeed*Time.deltaTime;
			transPos.y = 0;
			transform.position = transPos;
			if (Vector3.Distance (transform.position, player.transform.position) >= MaxDist+1) {
				backpedal = false;
			}
			return;
		}
		transform.LookAt(player.transform);
		//If far away, move towards the player
		if(Vector3.Distance(transform.position,player.transform.position) >= MinDist){

			Vector3 transPos = transform.position + transform.forward*MoveSpeed*Time.deltaTime;
			transPos.y = 0;
			transform.position = transPos;
			guardAnimator.SetBool ("Moving", true);

		}
		//If close to player, attack.
		if(Vector3.Distance(transform.position,player.transform.position) <= MaxDist)
		{
			guardAnimator.SetTrigger("Attack");
			SoundAdapter.playSwordSound ();
			player.GetComponent<TankController> ().takeDamage (1);
			AchievementController.hasBeenDamagedByTraps = true;
			backpedal = true;
		} 
	}

	public override void takeDamage(int damage){
		currentHealth -= damage;
		SoundAdapter.playMinionSound ();
		if (currentHealth <= 0) {
			Instantiate(explosion, this.gameObject.transform.position, new Quaternion(0,0,0,0));
			Destroy(gameObject);
		}
	}
}
		