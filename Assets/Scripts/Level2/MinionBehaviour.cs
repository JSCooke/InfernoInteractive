using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinionBehaviour : MonoBehaviour
{

	public UnityEngine.GameObject player = null;
	public float attackDistance = 5f;

	private Rigidbody rb;
	private int currentHealth, maxHealth;

	private bool movingTowards = false;
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
		movingTowards = true;
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
			movingTowards = false;
		} else
		{
			transform.position = transform.position;
		}
	}

	IEnumerator OnCollisionExit(Collision collision)
	{
		string collidedTag = collision.gameObject.tag;
		if (collidedTag == "Player")
		{
			yield return new WaitForSeconds(1);
			movingTowards = true;
		}
	}

	private void fightPlayer()
	{
		find();

		if (movingTowards) {
			moveTowards();
		}
	}

	private void moveTowards()
	{
		//if (Vector3.Distance(transform.position, playerPosition) <= attackDistance)
		//{
		//	return;
		//}
		transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime * 6);
	}

	private void find()
	{
		//Look at the player
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(this.transform.position - player.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
		playerPosition = player.transform.position;
		playerPosition = new Vector3(playerPosition.x, 0, playerPosition.z);
	}

	void Die()
	{
		Destroy(this.gameObject);
	}
}