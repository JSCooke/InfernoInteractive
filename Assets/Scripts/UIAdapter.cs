using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
	public Animator winAnimator;

	public TimerScript timer;

	public Image achievementImageBox;
	public Text achievementTextBox;

	//This needs to be altered in this class to show points earned.
	public Text winText;

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
	public int[] getTime() {
		return timer.getTime ();
	}
	//Decreases (negative values will increase) the player's health by the input percentage.
	//Returns the remaining hp of the player.
	public float damagePlayer(float hp){
		if (!playerDead () && !bossDead()) {
			playerVal -= hp;
			PlayerVal = playerVal;
		}
		return PlayerVal;
	}

	//Reduces (negative increases) the boss's health by the input percentage.
	//Returns the remaining hp of the boss.
	public float damageBoss(float hp){
		if (!bossDead () && !playerDead()) {
			bossVal -= hp;
			BossVal = bossVal;
		}
		return BossVal;
	}

	//Overload allowing bosses of higher hp to be damaged correctly.
	public float damageBoss(float hp, float maxHp){
		return damageBoss (BarScript.Map (hp, 0, maxHp, 0, 100));
	}

	//Causes an achievement box to pop up.
	public void achieve(String achievementText, Sprite achievementSprite){
		achievementTextBox.text = achievementText;	//Change text to whatever achievement value is.
		achievementImageBox.sprite = achievementSprite;	//Change sprite to whatever achievement sprite is.
		achievementAnimator.SetTrigger ("Achievement");
	}
	public void die(){
		deathAnimator.SetTrigger ("Death");
		stopTimer ();
	}
	public void win(){
		stopTimer ();
		//More complex scores may be used later. For now, for every second under 10 minutes gets a point.
		int points = 600 - (timer.getTime() [0] * 60) - (timer.getTime() [1]);
		//Prevent negative scores
		if (points < 0) {
			points = 0;
		}
		winText.text = "You Win!" +
			"\nYou finished the level in: " + timer.getTime() [0].ToString("D2") + ":" +timer.getTime() [1].ToString("D2") +
			"\nThis earns you: " + Convert.ToString (points) + " points!";	//This would be fun if we animate it ticking up, as the time ticks down.
		winAnimator.SetTrigger ("Win");
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
