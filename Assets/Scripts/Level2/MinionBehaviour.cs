using UnityEngine;
using System.Collections;

public class MinionBehaviour : MonoBehaviour
{

	public UnityEngine.GameObject player = null;

	private Rigidbody rb;
	private int currentHealth, maxHealth;

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
	}

	// Update is called once per frame
	void Update()
	{
		currentHealth = this.GetComponent<BossController>().currentHealth;

		if (currentHealth <= 0)
		{
			Die();
		}

		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		//agent.Warp(player.transform.position);
		//agent.destination = player.transform.position;
	}

	void OnCollisionEnter(Collision collision)
	{

		string collidedTag = collision.gameObject.tag;
		if (collidedTag == "Player" || collidedTag == "Enemy")
		{
			//dashing = false;
			//finding = true;
		}
	}

	void Die()
	{
		Destroy(this.gameObject);
	}
}
