using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class AchievementController : MonoBehaviour {


    public string achievement1 = "Cannon King";
    public string achievement2 = "Untouchable!";
    public string achievement3 = "Speedrunner";

	public static bool hasBeenDamaged = false;
	public static bool hasUsedOnlyCannon = true;

    public Sprite achievement1Sprite;
    public Sprite achievement2Sprite;
    public Sprite achievement3Sprite;

	//static dictionary that stores the state of achievements, true if the achievement has been achieved
    public static Dictionary<string, bool> achievements = new Dictionary<string, bool>();
	//static dictionary that maps strings to the corresponding achievement sprite
    public static Dictionary<string, Sprite> achievementSprites = new Dictionary<string, Sprite>();

    public static AchievementController instance;

    // Use this for initialization
    void Start () {

        instance = this;

		//setup hashmap with achievements being fale
		if (!achievements.ContainsKey (achievement1)) {
			achievements.Add(achievement1, false);
		}
		if (!achievements.ContainsKey (achievement2)) {
			achievements.Add(achievement2, false);
		}
		if (!achievements.ContainsKey (achievement3)) {
			achievements.Add(achievement3, false);
		}

		//set up string to sprite mapping
		if (!achievementSprites.ContainsKey (achievement1)) {
			achievementSprites.Add(achievement1, achievement1Sprite);
		}
		if (!achievementSprites.ContainsKey (achievement2)) {
			achievementSprites.Add(achievement2, achievement1Sprite);
		}
		if (!achievementSprites.ContainsKey (achievement3)) {
			achievementSprites.Add(achievement3, achievement1Sprite);
		}
       
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void updateAchievement(string achievement, bool value)
    {
        achievements[achievement] = value;
    }

    public static void displayAchievements()
    {
        foreach (KeyValuePair<string, bool> entry in achievements)
        {
            // do something with entry.Value or entry.Key
            if (entry.Value == true)
            {
                print("Inhere");
                print(entry.Key);

                UIAdapter.achieve(entry.Key, achievementSprites[entry.Key]);
                
                //add the static dictionaries to the gamedata
                GameData.put("Achievements", new AchievementController());
            }
        }
    }

}
