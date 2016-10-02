using UnityEngine;
using System.Collections;

public class BossController : Damageable {

    //Boss properties
    public float rotationSpeed = 5;
    public float bossSpeed;

    //Difficulty affects the attack speed
    public float difficulty = 2;

    // Use this for initialization
    void Start () {

        currentHealth = maxHealth;
		maxHealth = currentHealth;

    }

	// Update is called once per frame
	void Update () {
        
    }

}