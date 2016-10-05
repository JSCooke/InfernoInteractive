﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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

	//Perhaps make a general animator?
	public static Animator achievementAnimator;
	public static Animator deathAnimator;
	public static Animator winAnimator;

	public static TimerScript timer;

	public static Image achievementImageBox;
	public static Text achievementTextBox;

	//This needs to be altered in this class to show points earned.
	public static Text winText;
		
	public static void stopTimer(){
		timer.Stop = true;
	}
	public static void startTimer(){
		timer.Stop = false;
	}
	//This returns an array of 2 floats representing the curent time.
	//The first (index 0) is the minutes, the second (index 1) is the seconds.
	public static int[] getTime() {
		return timer.getTime ();
	}
	//Decreases (negative values will increase) the player's health by the input percentage.
	//Returns the remaining hp of the player.
	public static float damagePlayer(float hp){
		if (!playerDead () && !bossDead()) {
			playerVal -= hp;
			PlayerVal = playerVal;
		}
		return PlayerVal;
	}

	//Reduces (negative increases) the boss's health by the input percentage.
	//Returns the remaining hp of the boss.
	public static float damageBoss(float hp){
		if (!bossDead () && !playerDead()) {
			bossVal -= hp;
			BossVal = bossVal;
		}
		return BossVal;
	}

	//Overload allowing bosses of higher hp to be damaged correctly.
	public static float damageBoss(float damage, float maxHp){
		return damageBoss (BarScript.Map (damage, 0, maxHp, 0, 100));
	}

	public static float damagePlayer(float damage, float maxHP) {
		return damagePlayer(BarScript.Map(damage, 0, maxHP, 0, 100));
	}

	//Causes an achievement box to pop up.
	public static void achieve(String achievementText, Sprite achievementSprite){
		achievementTextBox.text = achievementText;	//Change text to whatever achievement value is.
		achievementImageBox.sprite = achievementSprite;	//Change sprite to whatever achievement sprite is.
		achievementAnimator.SetTrigger ("Achievement");
	}
	public static void die(){
		deathAnimator.SetTrigger ("Death");
		stopTimer ();
	}
	public static void win(){
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
