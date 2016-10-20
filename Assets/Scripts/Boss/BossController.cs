using UnityEngine;
using System.Collections;

public class BossController : Damageable {

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
    void Start () {
        dead = false;
        currentHealth = maxHealth;
        difficulty = (int)difficultyLevel;
        
        //set difficulty level if set in menu
        if (GameData.get<Difficulty>("difficulty") != default(Difficulty)) {
            difficultyLevel= GameData.get<Difficulty>("difficulty");
            difficulty = (int)GameData.get<Difficulty>("difficulty");
        }

    }

    public override void takeDamage(float damage) {

        if (damage > currentHealth) {
            damage = currentHealth;
        }
        
		SoundAdapter.playBossHitSound ();
        currentHealth = currentHealth - damage;

        float tempHealth = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth == tempHealth || currentHealth == 0) {
			UIAdapter.damageBoss((float)damage, totalHealth);
        }
        print(currentHealth);
		if (Mathf.Floor (currentHealth) <= 0) {
			dead = true;
		}

    }

    

}

//100 : 50 50 : 25 25 25 25 : 300
//100 : 50 50 50 : 25 25 25 25 25 25 25 25 25 : 500
//100 : 50 50 50 50 : 25 25 25 25 25 25 25 25 25 25 25 25 25 25 25 25 : 700

//2 = 300, 200
//3 = 500, 400
//4 = 700, 600