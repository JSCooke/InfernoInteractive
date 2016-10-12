using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinionBehaviour : MonoBehaviour
{

	public UnityEngine.GameObject player = null;
	public float attackDistance = 10.0f;

	public double moveAwayDuration;
	public int moveAwaySpeed;
	private double moveAwayStartTime;

	private Rigidbody rb;
	private Animator anim;
	private int currentHealth, maxHealth;

	private bool movingTowards = false;
	private bool movingAway = false;
	private bool active = false;

	private Vector3 playerPosition;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();

		maxHealth = this.GetComponent<BossController>().maxHealth;
		currentHealth = maxHealth;

		if (player == null)
		{
			player = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
		}
	}

	// Update is called once per frame
	void Update()
	{
		currentHealth = this.GetComponent<BossController>().currentHealth;

		if (this.GetComponent<BossController>().dead)
		{
			Die();
		} else
		{
			fightPlayer();
		}

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
		find();

		if (movingTowards) {
			moveTowards();
		}
		if (movingAway)	{
			moveAway();
		}
	}

	private void moveAway()
	{
		transform.Translate(Vector3.left * moveAwaySpeed * Time.deltaTime);

		if (Time.fixedTime > (moveAwayStartTime + moveAwayDuration))
		{
			movingAway = false;
			movingTowards = true;
		}
	}

	private void moveTowards()
	{
		anim.SetBool("Move", true);
		transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime);
	}

	private void find()
	{
		playerPosition = player.transform.position;
		playerPosition = new Vector3(playerPosition.x, 0, playerPosition.z);

		//Look at the player
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position- this.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
	}

	void Die()
	{
		Destroy(this.gameObject);
	}
}