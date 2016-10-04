using System;
using UnityEngine;
using UnityEngine.UI;

public class UIAdapter : MonoBehaviour
{
    public BarScript playerBar, bossBar;

    void Start() {
        player = playerBar;
        boss = bossBar;
    }

    void Update() {
        //print(boss);
    }

    public static BarScript player;
	public static float playerVal = 100;
	public static float PlayerVal {
		get {
			return playerVal;
		}
		set { 
			player.Value = playerVal;
		}
	}

	public static BarScript boss;
	public static float bossVal = 100;
	public static float BossVal {
		get {
			return bossVal;
		}
		set { 
			boss.Value = bossVal;
		}
	}
	public static Animator achievementAnimator;
	//Reduces (negative increases) the player's health by the input percentage.
	//Returns the remaining hp of the player.
	public static float damagePlayer(float hp){
		playerVal -= hp;
		PlayerVal = playerVal;

        return PlayerVal;
	}
	//Reduces (negative increases) the boss's health by the input percentage.
	//Returns the remaining hp of the boss.
	public static float damageBoss(float hp){
		bossVal -= hp;
		BossVal = bossVal;

		return BossVal;
	}

    public static float damageBoss(float damage, float maxHP) {
        return damageBoss(BarScript.Map(damage, 0, maxHP, 0, 100));
    }

    public static float damagePlayer(float damage, float maxHP) {
        return damagePlayer(BarScript.Map(damage, 0, maxHP, 0, 100));
    }

    //Causes an achievement box to pop up.
    //Add paramters to specify details about the achievement.
    public static void achieve(){
		achievementAnimator.SetTrigger ("Achievement");
	}
	//Returns true if the player is dead.
	public static bool playerDead() {
		if (PlayerVal == 0){
			return true;
		}else{
			return false;
		}
	}
	//Returns true if the boss is dead.
	public static bool bossDead() {
		if (BossVal == 0){
			return true;
		}else{
			return false;
		}
	}
}

