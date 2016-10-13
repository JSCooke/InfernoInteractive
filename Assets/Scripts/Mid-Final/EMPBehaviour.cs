using UnityEngine;
using System.Collections;

public class EMPBehaviour : Damageable
{

    


	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
       
	
	}

    public void takeDamage(int amount)
    {
        
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
