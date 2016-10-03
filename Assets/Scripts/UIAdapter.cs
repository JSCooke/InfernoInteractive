using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIAdapter
{
	public BarScript player;
	public float playerVal;
	public float PlayerVal {
		get {
			return playerVal;
		}
		set { 
			playerVal = Mathf.Clamp(value, 0, 100);
			player.Value = playerVal;
		}
	}

	public BarScript boss;
	public float bossVal;
	public float BossVal {
		get {
			return bossVal;
		}
		set { 
			bossVal = Mathf.Clamp(value, 0, 100);
			boss.Value = bossVal;
		}
	}

	//Perhaps make a general animator?
	public Animator achievementAnimator;
	public Animator deathAnimator;

	public TimerScript timer;

	public UIAdapter ()
	{
	}

	public void stopTimer(){
		timer.Stop = true;
	}
	public void startTimer(){
		timer.Stop = false;
	}
	//This returns an array of 2 floats representing the curent time.
	//The first (index 0) is the minutes, the second (index 1) is the seconds.
	public float[] getTime() {
		return timer.getTime ();
	}
	//Decreases (negative values will increase) the player's health by the input percentage.
	//Returns the remaining hp of the player.
	public float damagePlayer(float hp){
		if (!playerDead ()) {
			playerVal -= hp;
			PlayerVal = playerVal;
		}
		return PlayerVal;
	}

	//Reduces (negative increases) the boss's health by the input percentage.
	//Returns the remaining hp of the boss.
	public float damageBoss(float hp){
		if (!bossDead ()) {
			bossVal -= hp;
			BossVal = bossVal;
		}
		return BossVal;
	}

	//Causes an achievement box to pop up.
	//Add paramters to specify details about the achievement.
	public void achieve(){
		achievementAnimator.SetTrigger ("Achievement");
	}
	public void die(){
		deathAnimator.SetTrigger ("Death");
		stopTimer ();
	}

	//Returns true if the player is dead.
	public bool playerDead() {
		if (PlayerVal == 0){
			return true;
		}else{
			return false;
		}
	}

	//Returns true if the boss is dead.
	public bool bossDead() {
		if (BossVal == 0){
			return true;
		}else{
			return false;
		}
	}
}
