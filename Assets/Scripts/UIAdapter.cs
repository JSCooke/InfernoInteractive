﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;

public class UIAdapter : MonoBehaviour
{
	public int level;

	public GameObject tempRedOrbIndicator, tempGreenOrbIndicator;
	public static GameObject redOrbIndicator, greenOrbIndicator;
	//All UI components are passed in as fields
	public BarScript playerBar, bossBar;
	public Image bar1, bar2;
	public Image playerPic, bossPic;
    public Sprite playerAngry;
    public Sprite playerNeutral;
    public Sprite playerHappy;
	public Animator deathA, winA, achievementA, playerA, bossA;
	public TimerScript tempTimer;
	public Image tempAchievementImageBox;
	public Text tempAchievementTextBox;
	public Text tempWinText, tempDieText;
	public GameObject tempLeaderboardCanvas;

	public AnimationClip amin;
    private static bool isEMP = false;

    public static void setEMPMode(bool emp)
    {
        isEMP = emp;
    }

	//Used for when the player dies to an extremely obvoius trap
	private static bool idiot = false;

	public static bool Idiot {
		get {
			return idiot;
		}
		set {
			idiot = value;
		}
	}

    //ben made this
    public static Image topBar,bottomBar;
	public static int currentLevel;
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
    public static Sprite statPlayerAngry;
    public static Sprite statPlayerNeutral;
    public static Sprite statPlayerHappy;

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
	public static Animator playerDamageAnimator;
	public static Animator bossDamageAnimator;

	public static TimerScript timer;

	public static Image achievementImageBox;
	public static Text achievementTextBox;

	public static Canvas leaderboardCanvas;
	private static int points;

	//This needs to be altered in this class to show points earned.
	public static Text winText;
	public static Text dieText;

	void Start() {
		//Assign all variables passed in to the static variables.
		currentLevel = level;
		topBar = bar1;
		bottomBar = bar2;
		playerPortrait = playerPic;
        playerPortrait.sprite = playerHappy;
		bossPortrait = bossPic;
		player = playerBar;
		boss = bossBar;
		achievementAnimator = achievementA;
		winAnimator = winA;
		deathAnimator = deathA;
		playerDamageAnimator = playerA;
		bossDamageAnimator = bossA;
		achievementImageBox = tempAchievementImageBox;
		achievementTextBox = tempAchievementTextBox;
		winText = tempWinText;
		dieText = tempDieText;
		timer = tempTimer;
		leaderboardCanvas = tempLeaderboardCanvas.GetComponent<Canvas>();

		playerVal = 100;
		bossVal = 100;

		//print (tempRedOrbIndicator);
		//print (tempGreenOrbIndicator);
		redOrbIndicator = tempRedOrbIndicator;
		greenOrbIndicator = tempGreenOrbIndicator;

        statPlayerAngry = playerAngry;
        statPlayerHappy = playerHappy;
        statPlayerNeutral = playerNeutral;
	}

	void Update() {
		//print(boss);
	}
	/**
	 * Stops the timer, can be started with startTimer.
	 */ 	
	public static void stopTimer(){
		timer.Stop = true;
	}
	/**
	 * Starts the timer, can be stopped with stopTimer.
	 */ 
	public static void startTimer(){
		timer.Stop = false;
	}
	/**
	 * This returns an array of 2 floats representing the curent time.
	 * The first (index 0) is the minutes, the second (index 1) is the seconds.
	 */ 
	public static int[] getTime() {
		return timer.getTime ();
	}
    /**
	 * This returns the time in seconds
	 */
    public static int getTimeInSeconds() {
        return getTime()[0] * 60 + getTime()[1];
    }

	/**
	 * Decreases (negative values will increase) the player's health by the input percentage.
	 * Returns the remaining hp of the player. (Pass in 0 to use this as a getter)
	 */
	public static float damagePlayer(float hp){
		if (!playerDead () && (!bossDead() || isEMP)) {

            if (playerDamageAnimator != null && hp>0)
            {
			playerDamageAnimator.SetTrigger ("playerDamage");
            }
			playerVal -= hp;
			PlayerVal = playerVal;
            if(((float)33.0 < playerVal) && (playerVal < (float)66.0))
            {
                playerPortrait.sprite = statPlayerNeutral;
                //Debug.LogError(playerVal);
            }
            else if(playerVal < 33.0)
            {
                playerPortrait.sprite = statPlayerAngry;
                Debug.LogError(playerVal+"MOREEE");

            }
		}
		if (playerDead())
		{
			die();
		}
		return PlayerVal;
	}

	/**
	 * Reduces (negative increases) the boss's health by the input percentage.
	 * Returns the remaining hp of the boss. (Pass in 0 to use this as a getter)
	 */ 
	public static float damageBoss(float hp){
		if ((!bossDead ()|| isEMP) && !playerDead()) {
            if(bossDamageAnimator!= null && hp>0)
            {
			    bossDamageAnimator.SetTrigger ("bossDamage");

            }
			bossVal -= hp;

            if (bossVal <= 0)
            {
                bossVal = 0;
            }
            if (bossVal > 100) {
                bossVal = 100;
            }

			BossVal = bossVal;
			if (bossDead ()&&!isEMP) {
				win ();
			}
		}
		return BossVal;
	}

	/**
	 * Overload of damagePlayer allowing for players to have max hp other than 100
	 * Pass in the max HP as the second value and it will perform the calculation
	 */
	public static float damageBoss(float damage, float maxHp){
		return damageBoss (BarScript.Map (damage, 0, maxHp, 0, 100));
	}
	/**
	 * Overload of damagePlayer allowing for players to have max hp other than 100
	 * Pass in the max HP as the second value and it will perform the calculation
	 */ 
	public static float damagePlayer(float damage, float maxHP) {
		return damagePlayer(BarScript.Map(damage, 0, maxHP, 0, 100));
	}

	/**
	 * Causes an achievement box to pop up.
	 * Pass in text and a sprite, and they'll be on the box.
	 */
	 public static void achieve(String achievementText, Sprite achievementSprite){
		achievementTextBox.text = achievementText;	//Change text to whatever achievement value is.
		achievementImageBox.sprite = achievementSprite;	//Change sprite to whatever achievement sprite is.
		achievementAnimator.SetTrigger ("Achievement");
    }
	/**
	 * Calls up the death screen, and stops the timer.
	 */ 
	public static void die(){
        if (!idiot) {
            dieText.text = "You died...";
        }
        else {
            dieText.text = "It's not like we didn't warn you...";
            Idiot = false;
        }
        deathAnimator.gameObject.SetActive(true);
		deathAnimator.SetTrigger ("Death");
		stopTimer ();
	}

	/**
	 * Calls up the win screen, stops the timer and calculates the score.
	 * Also checks for achivements.
	 */
	public static void win(){
        winAnimator.gameObject.SetActive(true);
		stopTimer ();
		List<string> achievementsToDisplay = new List<string> ();

		//Achievements for level 1
		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			//update all achievement values
			if (!AchievementController.hasBeenDamaged) {
				AchievementController.updateAchievement ("Untouchable!", !AchievementController.hasBeenDamaged);
				achievementsToDisplay.Add ("Untouchable!");
			}
			if (AchievementController.hasUsedOnlyCannon) {
				AchievementController.updateAchievement ("Cannon King", AchievementController.hasUsedOnlyCannon);
				achievementsToDisplay.Add ("Cannon King");

			}
			//if the time taken to win is longer than 70 you fail the achievement
			if ((timer.getTime () [0] * 60) + (timer.getTime () [1]) < 70) {
				//fail the speed runner achievement
				AchievementController.updateAchievement ("Speedrunner", true);
				achievementsToDisplay.Add ("Speedrunner");
			}
		}

        //cycle through all achievements youved gained
        AchievementController.displayAchievements(achievementsToDisplay);

        //More complex scores may be used later. For now, for every second under 10 minutes gets a point.
        points = 600 - (timer.getTime() [0] * 60) - (timer.getTime() [1]);
		//Prevent negative scores
		if (points < 0) {
			points = 0;
		}

		////Add player score to leaderboard
		if (isHighScore(points))
		{
			UIAdapter.leaderboardCanvas.enabled = true;
		}
		
		winText.text = "You Win!" +
			"\nYou finished the level in: " + timer.getTime() [0].ToString("D2") + ":" +timer.getTime() [1].ToString("D2") +
			"\nThis earns you: " + Convert.ToString (points) + " points!";	//This would be fun if we animate it ticking up, as the time ticks down.
		winAnimator.SetTrigger ("Win");
	}

	/**
	 * Returns true if the player is dead.
	 */ 
	public static bool playerDead() {
		if (Mathf.Floor(PlayerVal) == 0){
			return true;
		}else{
			return false;
		}
	}

	/**
	 * Returns true if the boss is dead.
	 */ 
	public static bool bossDead() {
		if (Mathf.Floor(BossVal) == 0){
			return true;
		}else{
			return false;
		}
	}

	/**
	 * The boss hp is by default invisible.
	 * Call this method and pass in true when a boss is spawned to make the health bar appear.
	 * To make it disappear, pass in false.
	 */ 
	public static void setBossUI(bool ui){
		//print (ui);
		topBar.gameObject.SetActive (ui);
		//bottomBar.gameObject.SetActive (ui);
		//playerPortrait.gameObject.SetActive (ui);
		bossPortrait.gameObject.SetActive (ui);

	    bossPortrait.enabled = ui;
		boss.enabled = ui;
	}

	public static void addScoreToLeader(String name){

		BossController.Difficulty difficulty = GameData.get<BossController.Difficulty>("difficulty");
		if (difficulty == default(BossController.Difficulty))
		{
			difficulty = BossController.Difficulty.Easy;
		}

		List<LeaderboardEntry> leaders = GameData.get<List<LeaderboardEntry>>(currentLevel.ToString() + difficulty); //stands for level number and difficulty

		// current player's score
		LeaderboardEntry entry = new LeaderboardEntry(name, points);

		if (leaders == null)
		{
			leaders = new List<LeaderboardEntry>();
		}

		leaders.Add(entry);
		// sort the list and trim if more than 6 entries
		leaders.Sort(delegate (LeaderboardEntry e1, LeaderboardEntry e2) { return e2.score.CompareTo(e1.score); });
		if (leaders.Count > 6)
		{
			leaders.RemoveAt(6);
		}

		GameData.put(currentLevel.ToString() + difficulty, leaders);
	}

	private static Boolean isHighScore(int score)
	{
		BossController.Difficulty difficulty = GameData.get<BossController.Difficulty>("difficulty");
		if (difficulty == default(BossController.Difficulty))
		{
			difficulty = BossController.Difficulty.Easy;
		}

		List<LeaderboardEntry> leaders = GameData.get<List<LeaderboardEntry>>(currentLevel.ToString() + difficulty); //stands for level number and difficulty

		if ((leaders == null) || (leaders.Count < 6) || (score > leaders[leaders.Count - 1].score))
		{
			return true;
		}
		return false;
	}

	/**
	 * Turns the red orb indicator on or off
	 */
	public static void setRedOrbActive(bool active){
		print (redOrbIndicator);
		UIAdapter.redOrbIndicator.SetActive (active);
	}

	/**
	 * Turns the green orb indicator on or off
	 */
	public static void setGreenOrbActive(bool active){
		print (UIAdapter.greenOrbIndicator);
		UIAdapter.greenOrbIndicator.SetActive (active);
	}
}
