using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossDoorController : MonoBehaviour {
    public bool open;
    public GameObject leftDoor, rightDoor, dialogObjectiveZone;
    public float speed, openOffset;
    public bool redOrb = false;
    public bool greenOrb = false;
    private bool achievementUnlocked = false;

    private Vector3 leftDoorOpenPosition, rightDoorOpenPosition, leftDoorClosedPosition, rightDoorClosedPosition;
	// Use this for initialization
	void Start () {
        leftDoorClosedPosition = leftDoor.transform.localPosition;
        rightDoorClosedPosition = rightDoor.transform.localPosition;
        leftDoorOpenPosition =
            new Vector3(
                leftDoorClosedPosition.x - openOffset,
                leftDoorClosedPosition.y,
                leftDoorClosedPosition.z);
        rightDoorOpenPosition =
            new Vector3(
                rightDoorClosedPosition.x + openOffset,
                rightDoorClosedPosition.y,
                rightDoorClosedPosition.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (open) {
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, leftDoorOpenPosition, speed * Time.deltaTime);
            rightDoor.transform.localPosition = Vector3.MoveTowards(rightDoor.transform.localPosition, rightDoorOpenPosition, speed * Time.deltaTime);
        } else {
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, leftDoorClosedPosition, speed * Time.deltaTime);
            rightDoor.transform.localPosition = Vector3.MoveTowards(rightDoor.transform.localPosition, rightDoorClosedPosition, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && redOrb && greenOrb)
        {
			if (!open) {
				SoundAdapter.playClickSound ();
			}
			open = true;

            //Check if player met achievement criteria
            if (!AchievementController.hasBeenDamagedL3 && !achievementUnlocked) {
                AchievementController.updateAchievement("Orb Master", true);
                List<string> achievementsToDisplay = new List<string>();
                achievementsToDisplay.Add("Orb Master");
                AchievementController.displayAchievements(achievementsToDisplay);
                achievementUnlocked = true;
            }

            //Enable the dialog and objective zone
            dialogObjectiveZone.SetActive(true);
        }
    }
}
