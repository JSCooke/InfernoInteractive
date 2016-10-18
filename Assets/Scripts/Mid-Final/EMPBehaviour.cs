using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EMPBehaviour : Damageable
{
    float healthIncreamentTime = 1f;
    float timer;

    public Image bossPic;

    int empIncreaseValue = 1;

    bool win = false;

    bool first = true;



    // Use this for initialization
    void Start()
    {
        UIAdapter.changeEMP();
        timer = 0f;
        maxHealth = 100;
        currentHealth = 0;
        //UIAdapter.bossVal = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (first)
        {
            UIAdapter.bossVal = 0;
            first = false;
        }

        timer += Time.deltaTime;

        if (!win)
        {
            //increase
            if (timer >= healthIncreamentTime)
            {
                increaseHealth();
                timer = 0f;
            }
        }
    }

    public void takeDamage(int amount)
    {
        //damage
        int health = currentHealth - amount;

        if (health < 0)
        {
            currentHealth = 1;
            amount = currentHealth - 1;
        }

        UIAdapter.damageBoss((float)amount);

        timer = 0f;
    }

    void increaseHealth()
    {
        currentHealth = currentHealth + empIncreaseValue;
        UIAdapter.damageBoss((float)-empIncreaseValue);
        if (currentHealth >= 100)
        {
            win = true;
            UIAdapter.win();
        }
    }

}
