using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinionBehaviour : MonoBehaviour
{

	public UnityEngine.GameObject player = null;
	public float attackDistance = 6f;

	private Rigidbody rb;
	private int currentHealth, maxHealth;

	//private bool moving = false;
	//private bool finding = true;

	private Vector3 playerPosition;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();

		maxHealth = this.GetComponent<BossController>().maxHealth;
		currentHealth = maxHealth;

		if (player == null)
		{
			player = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
		}
		find();
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
	}

	void OnCollisionEnter(Collision collision)
	{

		string collidedTag = collision.gameObject.tag;
		if (collidedTag == "Player")
		{
			//dashing = false;
			//finding = true;
		}
	}

	private void fightPlayer()
	{
		find();
		move();
		//if ((transform.position - playerPosition) > attackDistance)
		//{

		//}
		//if (moving) { move(); }
		//else if (finding) {	find();	}

	}

	private void move()
	{
		if (Vector3.Distance(transform.position, playerPosition) <= attackDistance)
		{
			return;
		}
		//playerPosition = player.transform.position;
		//transform.Translate(Vector3.left * 5f * Time.deltaTime);
		transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime * 6);
	}

	private void find()
	{
		//Look at the player
		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(this.transform.position - player.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
		playerPosition = player.transform.position;
		Vector3 targetDir = playerPosition - transform.position;
		float step = this.GetComponent<BossController>().rotationSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
	}

	void Die()
	{
		Destroy(this.gameObject);
	}
}