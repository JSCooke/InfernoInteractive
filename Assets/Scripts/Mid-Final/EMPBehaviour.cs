using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EMPBehaviour : Damageable
{
    float healthIncreamentTime = 1f;
    float timer;

    public Image bossPic;

    int empIncreaseValue = 1;



    // Use this for initialization
    void Start () {

        UIAdapter.bossPortrait = bossPic;
        UIAdapter.bossVal = 1;

        timer = 0f;
        maxHealth = 100;
        currentHealth = 1;
    }
	
	// Update is called once per frame
	void Update () {
        
        timer += Time.deltaTime;

        //increase
        if (timer >= healthIncreamentTime)
        {
            increaseHealth();
            timer = 0f;
        }
	
	}

    public void takeDamage(int amount)
    {
        //damage
        int health = currentHealth - amount;

        if (health < 1)
        {
            currentHealth = 1;
            amount = currentHealth - 1;
        }

        UIAdapter.damageBoss((float)amount);

        timer = 0f;

        Debug.Log("emp health " + currentHealth);

    }

    void increaseHealth()
    {
        currentHealth = currentHealth + empIncreaseValue;
        UIAdapter.damageBoss((float)-empIncreaseValue);
        if (currentHealth >= 100)
        {
            UIAdapter.win();
        }

        Debug.Log("emp health " + currentHealth);
    }

}
