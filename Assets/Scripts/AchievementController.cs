using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class AchievementController : MonoBehaviour {

	//level1
    public string achievement1 = "Cannon King";
    public string achievement2 = "Untouchable!";
    public string achievement3 = "Speedrunner";
    
	//level2
	public string achievement7 = "Puzzle Master";
	public string achievement8 = "Who needs a shield";
	public string achievement9 = "Traps? what traps?";

	//level3
	public string achievement4 = "Orb Master";


    //level 1
    public static bool hasBeenDamaged = false;
    public static bool hasUsedOnlyCannon = true;

	//level 2
	public static bool hasFailedBoxStage = false;
	public static bool hasUsedShield = false;
	public static bool hasBeenDamagedByTraps = false;

	//level 3
	public static bool hasBeenDamagedL3 = false;

    public Sprite achievement1Sprite;
    public Sprite achievement2Sprite;
    public Sprite achievement3Sprite;

    public Sprite achievement4Sprite;

	public Sprite achievement7Sprite;
	public Sprite achievement8Sprite;
	public Sprite achievement9Sprite;

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
		hasFailedBoxStage = false;
		hasUsedShield = false;

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


		if (!achievements.ContainsKey(achievement7))
		{
			achievements.Add(achievement7, false);
		}
		if (!achievements.ContainsKey(achievement8))
		{
			achievements.Add(achievement8, false);
		}
		if (!achievements.ContainsKey(achievement9))
		{
			achievements.Add(achievement9, false);
		}

        load();

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


		if (!achievementSprites.ContainsKey(achievement7))
		{
			achievementSprites.Add(achievement7, achievement7Sprite);
		}
		if (!achievementSprites.ContainsKey(achievement8))
		{
			achievementSprites.Add(achievement8, achievement8Sprite);
		}
		if (!achievementSprites.ContainsKey(achievement9))
		{
			achievementSprites.Add(achievement9, achievement9Sprite);
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
        save();
	}

    public static void save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/achievements.dat");

        Data data = new Data();
        data.achievements = achievements;

        bf.Serialize(file, data);
        file.Close();
    }

    public static void load() {
        if (File.Exists(Application.persistentDataPath + "/achievements.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/achievements.dat", FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();

            achievements = data.achievements;
        }
    }

    [Serializable]
    class Data {
        public Dictionary<string, bool> achievements;
    }

}
