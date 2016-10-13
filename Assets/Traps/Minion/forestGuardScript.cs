using UnityEngine;
using System.Collections;

public class forestGuardScript : Damageable {

	public ParticleSystem explosion;
	public Animator guardAnimator;
	public GameObject player;
	int MoveSpeed = 4;
	int MaxDist = 6;
	int MinDist = 4;

	void Start () 
	{
		player = GameObject.Find ("Tank");
		explosion.playbackSpeed = 1f;
		maxHealth = 50;
		currentHealth = maxHealth;
		damagedBy = "PlayerProjectile";
	}

	void Update () 
	{
		transform.LookAt(player.transform);

		if(Vector3.Distance(transform.position,player.transform.position) >= MinDist){

			Vector3 transPos = transform.position + transform.forward*MoveSpeed*Time.deltaTime;
			transPos.y = 0;
			transform.position = transPos;
			guardAnimator.SetBool ("Moving", true);

		}
		if(Vector3.Distance(transform.position,player.transform.position) <= MaxDist)
		{
			guardAnimator.SetTrigger("Attack");
			player.GetComponent<TankController> ().takeDamage (4);

		} 
	}

	public override void takeDamage(int damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Instantiate(explosion, this.gameObject.transform.position, new Quaternion(0,0,0,0));
			Destroy(gameObject);
		}
	}
}
		