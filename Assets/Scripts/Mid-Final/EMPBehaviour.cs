using UnityEngine;
using System.Collections;

public class EMPBehaviour : Damageable
{
    float healthIncreamentTime = 1f;
    float timer;

    

    // Use this for initialization
    void Start () {
        timer = 0f;
        maxHealth = 100;
        currentHealth = 0;
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
        currentHealth = currentHealth - amount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        timer = 0f;
    }

    void increaseHealth()
    {
        currentHealth = currentHealth + 1;
        if (currentHealth >= 100)
        {
            //win
        }
    }

    /**
 * Reduces (negative increases) the boss's health by the input percentage.
 * Returns the remaining hp of the boss. (Pass in 0 to use this as a getter)
 */
    //override
    //public static float damageBoss(float hp)
    //{
    //    if (!bossDead() && !playerDead())
    //    {
    //        bossDamageAnimator.SetTrigger("bossDamage");
    //        bossVal -= hp;
    //        BossVal = bossVal;
    //        if (bossDead())
    //        {
    //            win();
    //        }
    //    }
    //    return BossVal;
    //}
}
