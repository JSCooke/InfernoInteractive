using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class AchievementController : MonoBehaviour {


    public string achievement1 = "Cannon King";
    public string achievement2 = "Untouchable!";
    public string achievement3 = "Speedrunner";

    public Sprite achievement1Sprite;
    public Sprite achievement2Sprite;
    public Sprite achievement3Sprite;

    public static Dictionary<string, bool> achievements = new Dictionary<string, bool>();
    public static Dictionary<string, Sprite> achievementSprites = new Dictionary<string, Sprite>();

    public static AchievementController instance;

    // Use this for initialization
    void Start () {

        instance = this;

        achievements.Add(achievement1, true);
        achievements.Add(achievement2, true);
        achievements.Add(achievement3, true);

        achievementSprites.Add(achievement1, achievement1Sprite);
        achievementSprites.Add(achievement2, achievement2Sprite);
        achievementSprites.Add(achievement3, achievement3Sprite);

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
