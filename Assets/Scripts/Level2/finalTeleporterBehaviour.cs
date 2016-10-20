using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class finalTeleporterBehaviour : MonoBehaviour {

    public TankController tank;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter(Collider other) {

        UIAdapter.win();

        //check for the trap master achievement
        List<string> achievementsToDisplay = new List<string>();
        if (!AchievementController.hasBeenDamagedByTraps) {
            AchievementController.updateAchievement("Traps? what traps?", !AchievementController.hasBeenDamagedByTraps);
            achievementsToDisplay.Add("Traps? what traps?");

            //cycle through all achievements youved gained
            AchievementController.displayAchievements(achievementsToDisplay);

        }

        Destroy(this.gameObject);


    }

    }
