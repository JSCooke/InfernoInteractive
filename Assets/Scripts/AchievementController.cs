using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class AchievementController : MonoBehaviour {


    public string achievement1 = "Cannon King";
    public string achievement2 = "Untouchable!";
    public string achievement3 = "Speedrunner";
    public string achievement4 = "Orb Master";
    
    public static bool hasBeenDamaged = false;
    public static bool hasBeenDamagedL3 = false;
    public static bool hasUsedOnlyCannon = true;

    public Sprite achievement1Sprite;
    public Sprite achievement2Sprite;
    public Sprite achievement3Sprite;
    public Sprite achievement4Sprite;

    //static dictionary that stores the state of achievements, true if the achievement has been achieved
    public static Dictionary<string, bool> achievements = new Dictionary<string, bool>();
	//static dictionary that maps strings to the corresponding achievement sprite
    public static Dictionary<string, Sprite> achievementSprites = new Dictionary<string, Sprite>();

	public static Queue<string> achievementQueue = new Queue<string>();

    public static AchievementController instance;

    // Use this for initialization
    void Start () {
        hasBeenDamaged = false;
        hasUsedOnlyCannon = true;

        instance = this;

		//setup hashmap with achievements being false
		if (!achievements.ContainsKey (achievement1)) {
			achievements.Add(achievement1, false);
		}
		if (!achievements.ContainsKey (achievement2)) {
			achievements.Add(achievement2, false);
		}
		if (!achievements.ContainsKey (achievement3)) {
			achievements.Add(achievement3, false);
		}
        if (!achievements.ContainsKey(achievement4))
        {
            achievements.Add(achievement4, false);
        }

        //set up string to sprite mapping
        if (!achievementSprites.ContainsKey (achievement1)) {
			achievementSprites.Add(achievement1, achievement1Sprite);
		}
		if (!achievementSprites.ContainsKey (achievement2)) {
			achievementSprites.Add(achievement2, achievement2Sprite);
		}
		if (!achievementSprites.ContainsKey (achievement3)) {
			achievementSprites.Add(achievement3, achievement3Sprite);
		}
        if (!achievementSprites.ContainsKey(achievement4))
        {
            achievementSprites.Add(achievement4, achievement4Sprite);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (UIAdapter.achievementAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Idle") && achievementQueue.Count != 0) {
			string achievementName = achievementQueue.Dequeue();
			print (achievementName+" is printing");
			UIAdapter.achieve (achievementName, achievementSprites [achievementName]);
		}
	}

    public static void updateAchievement(string achievement, bool value)
    {
        achievements[achievement] = value;
    }

    public static void displayAchievements(List<string> achievementsToDisplay)
    {
        foreach (string achievement in achievementsToDisplay)
        {
			achievementQueue.Enqueue(achievement);
        }

		//add the static dictionaries to the gamedata
		GameData.put("Achievements", new AchievementController());
	}

}
