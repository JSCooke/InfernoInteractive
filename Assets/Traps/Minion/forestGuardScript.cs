using UnityEngine;
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
	}

	void Update () 
	{
		if (backpedal) {
			transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
			Vector3 transPos = transform.position + transform.forward*MoveSpeed*Time.deltaTime;
			transPos.y = 0;
			transform.position = transPos;
			if (Vector3.Distance (transform.position, player.transform.position) >= MaxDist) {
				backpedal = false;
			}
		}
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
			player.GetComponent<TankController> ().takeDamage (1);
			backpedal = true;
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
		