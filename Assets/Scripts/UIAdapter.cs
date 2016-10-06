using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

public class UIAdapter : MonoBehaviour
{
	public BarScript playerBar, bossBar;
	public Image bar1, bar2;
	public Image playerPic, bossPic;
	public Animator deathA, winA, achievementA;
	public TimerScript tempTimer;

	public Image tempAchievementImageBox;
	public Text tempAchievementTextBox;

	//This needs to be altered in this class to show points earned.
	public Text tempWinText;

	public AnimationClip amin;


	//ben made this
	public static Image topBar,bottomBar;

	void Start() {
		topBar = bar1;
		bottomBar = bar2;
		playerPortrait = playerPic;
		bossPortrait = bossPic;
		player = playerBar;
		boss = bossBar;
		achievementAnimator = achievementA;
		winAnimator = winA;
		deathAnimator = deathA;
		achievementImageBox = tempAchievementImageBox;
		achievementTextBox = tempAchievementTextBox;
		winText = tempWinText;
		timer = tempTimer;
	}

	void Update() {
		//print(boss);
	}


	public static Image playerPortrait;
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

	public static Image bossPortrait;
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
	/** 	 * Stops the timer, can be started with startTimer. 	 */ 	
	public static void stopTimer(){
		timer.Stop = true;
	}
	/** 	 * Starts the timer, can be stopped with stopTimer. 	 */ 
	public static void startTimer(){
		timer.Stop = false;
	}
	/** 	 * This returns an array of 2 floats representing the curent time. 	 * The first (index 0) is the minutes, the second (index 1) is the seconds. 	 */ 
	public static int[] getTime() {
		return timer.getTime ();
	}
	/** 	 * Decreases (negative values will increase) the player's health by the input percentage. 	 * Returns the remaining hp of the player. (Pass in 0 to use this as a getter) 	 */
	public static float damagePlayer(float hp){
		if (!playerDead () && !bossDead()) {
			playerVal -= hp;
			PlayerVal = playerVal;

			if (playerDead ()) {
				die ();
			}
		}
		return PlayerVal;
	}

	/** 	 * Reduces (negative increases) the boss's health by the input percentage. 	 * Returns the remaining hp of the boss. (Pass in 0 to use this as a getter) 	 */ 
	public static float damageBoss(float hp){
		if (!bossDead () && !playerDead()) {
			bossVal -= hp;
			BossVal = bossVal;
			if (bossDead ()) {
				win ();
			}
		}
		return BossVal;
	}

	/** 	 * Overload of damagePlayer allowing for players to have max hp other than 100 	 * Pass in the max HP as the second value and it will perform the calculation 	 */
	public static float damageBoss(float damage, float maxHp){
		return damageBoss (BarScript.Map (damage, 0, maxHp, 0, 100));
	}
	/** 	 * Overload of damagePlayer allowing for players to have max hp other than 100 	 * Pass in the max HP as the second value and it will perform the calculation 	 */ 
	public static float damagePlayer(float damage, float maxHP) {
		return damagePlayer(BarScript.Map(damage, 0, maxHP, 0, 100));
	}

	/** 	 * Causes an achievement box to pop up. 	 * Pass in text and a sprite, and they'll be on the box. 	 */
	 public static void achieve(String achievementText, Sprite achievementSprite){
		print (achievementText+"changin text to ");
		achievementTextBox.text = achievementText;	//Change text to whatever achievement value is.
		achievementImageBox.sprite = achievementSprite;	//Change sprite to whatever achievement sprite is.
		achievementAnimator.SetTrigger ("Achievement");
    }
	/** 	 * Calls up the death screen, and stops the timer. 	 */ 
	public static void die(){
		deathAnimator.SetTrigger ("Death");
		stopTimer ();
	}

	/** 	 * Calls up the win screen, stops the timer and calculates the score. 	 * Also checks for achivements. 	 */
	public static void win(){
		print ("Winning");
		stopTimer ();
		//update all achievement values
		if (!AchievementController.hasBeenDamaged) {
			AchievementController.updateAchievement("Untouchable!", !AchievementController.hasBeenDamaged);
		}
		if (AchievementController.hasUsedOnlyCannon) {
			AchievementController.updateAchievement("Cannon King", AchievementController.hasUsedOnlyCannon);
		}
		//if the time taken to win is longer than 70 you fail the achievement
        if((timer.getTime()[0] * 60) - (timer.getTime()[1]) < 70)
        {
            //fail the speed runner achievement
            AchievementController.updateAchievement("Speedrunner", true);
        }
			

        //cycle through all achievements youved gained
        AchievementController.displayAchievements();

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

	/** 	 * Returns true if the player is dead. 	 */ 
	public static bool playerDead() {
		if (Mathf.Floor(PlayerVal) == 0){
			return true;
		}else{
			return false;
		}
	}

	/** 	 * Returns true if the boss is dead. 	 */ 
	public static bool bossDead() {
		if (Mathf.Floor(BossVal) == 0){
			return true;
		}else{
			return false;
		}
	}

	/** 	 * The boss hp is by default invisible. 	 * Call this method and pass in true when a boss is spawned to make the health bar appear. 	 * To make it disappear, pass in false. 	 */ 
	public static void setBossUI(bool ui){
		print ("GotCAlled");
		print (ui);
		topBar.gameObject.SetActive (ui);
		bottomBar.gameObject.SetActive (ui);
		playerPortrait.gameObject.SetActive (ui);
		bossPortrait.gameObject.SetActive (ui);

//		bossPortrait.enabled = ui;
//		boss.enabled = ui;
	}
}
