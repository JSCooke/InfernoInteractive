using UnityEngine;
using System.Collections;

public class BossController : Damageable {

    //Boss properties
    public float rotationSpeed = 5;
    public float bossSpeed = 5;

    //Difficulty affects the attack speed
    public float difficulty = 2;

    // Use this for initialization
    void Start () {

        //Regulate difficulty in case extreme values are set
        bossSpeed = Mathf.Max(bossSpeed, 8);
        bossSpeed = bossSpeed * (float)0.1;
        difficulty = Mathf.Min(difficulty, 10);

        currentHealth = maxHealth;
		maxHealth = currentHealth;

    }

	// Update is called once per frame
	void Update () {
        
    }

}