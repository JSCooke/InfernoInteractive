using UnityEngine;
using System.Collections;

public class MinionController : Damageable {

	//Boss properties
	public float rotationSpeed = 5;
	public float bossSpeed;

	//Difficulty affects the number of splits
	public enum Difficulty { Easy = 2, Medium = 3, Hard = 4 };
	public Difficulty difficultyLevel;

	public int difficulty = 0;
	public float totalHealth = 0;
	private bool achievementsDone = false;

	// Use this for initialization
	void Start()
	{
		dead = false;
		currentHealth = maxHealth;
		difficulty = (int)difficultyLevel;

		//set difficulty level if set in menu
		if (GameData.get<Difficulty>("difficulty") != default(Difficulty))
		{
			difficultyLevel = GameData.get<Difficulty>("difficulty");
			difficulty = (int)GameData.get<Difficulty>("difficulty");
		}

	}

	public override void takeDamage(int damage)
	{

		if (damage > currentHealth)
		{
			damage = currentHealth;
		}

		currentHealth = currentHealth - damage;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

		if (Mathf.Floor(currentHealth) <= 0)
		{
			dead = true;
		}
	}
}
