using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinionBehaviour : MonoBehaviour
{
	//Reference to player object
	public UnityEngine.GameObject player = null;
	//Distance at which minions should start moving
	public float attackDistance = 10.0f;

	//Fields to specify how to move away from player
	public double moveAwayDuration;
	public int moveAwaySpeed;
	private double moveAwayStartTime;

	//Properties of minion
	private Rigidbody rb;
	private Animator anim;
	private int currentHealth, maxHealth;

	//Booleans for minion's state
	private bool movingTowards = false;
	private bool movingAway = false;
	private bool active = false;

	//Position of player in game
	private Vector3 playerPosition;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();

		maxHealth = this.GetComponent<MinionController>().maxHealth;
		currentHealth = maxHealth;

		//Find player in game
		if (player == null)
		{
			player = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
		}
	}

	// Update is called once per frame
	void Update()
	{
		//Update health
		currentHealth = this.GetComponent<MinionController>().currentHealth;

		//If not dead, fight player
		if (this.GetComponent<MinionController>().dead)
		{
			Die();
		} else
		{
			fightPlayer();
		}

		//Activate when player is closer than attack distance
		if (!active)
		{
			if (Vector3.Distance(transform.position, playerPosition) <= attackDistance)
			{
				active = true;
				movingTowards = true;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		//If collided with player, move away for some time
		string collidedTag = collision.gameObject.tag;
		if (collidedTag == "Player")
		{
			movingTowards = false;
			movingAway = true;
			moveAwayStartTime = Time.fixedTime;
		} 
	}

	private void fightPlayer()
	{
		//Always update player position and turn towards player
		find();

		//Either move towards or away from player
		if (movingTowards) {
			moveTowards();
		}
		if (movingAway)	{
			moveAway();
		}
	}

	private void moveAway()
	{
		//Move away from player
		transform.Translate(Vector3.left * moveAwaySpeed * Time.deltaTime);

		//If move away duration has exceeded, go back to moving towards player
		if (Time.fixedTime > (moveAwayStartTime + moveAwayDuration))
		{
			movingAway = false;
			movingTowards = true;
		}
	}

	private void moveTowards()
	{
		//Move towards player and change animation from idle to move
		anim.SetBool("Move", true);
		transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<MinionController>().bossSpeed * Time.deltaTime);
	}

	private void find()
	{
		//Update player location and turn towards player
		playerPosition = player.transform.position;
		playerPosition = new Vector3(playerPosition.x, 0, playerPosition.z);

		//Look at the player
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position- this.transform.position), this.GetComponent<MinionController>().rotationSpeed * Time.deltaTime);
	}

	void Die()
	{
		Destroy(this.gameObject);
	}
}