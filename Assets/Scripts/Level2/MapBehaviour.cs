using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapBehaviour : MonoBehaviour {

	public int id;
	public float rotateSpeed = 1;
	public float translateSpeed = 1;
	public float translateAmplitude = 1;
    public Image map1;
    public Image map2;
    public Image map3;

    private Vector3 _startPosition;

	// Use this for initialization
	void Start () {
		_startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 20 * Time.deltaTime * rotateSpeed);

		transform.position = _startPosition + new Vector3(0.0f, translateAmplitude * Mathf.Sin(Time.time * translateSpeed), 0.0f);
	}

	public void OnTriggerEnter(Collider other)
	{
		// TODO "pick up" map

	
		if (id == 3 && other.gameObject.tag == "Player") // last map to collect and it's actually the player hitting it
		{
            map1.gameObject.SetActive(false);
            map2.gameObject.SetActive(false);
            map3.gameObject.SetActive(true);

            UIAdapter.win();

			//check for the trap master achievement
			List<string> achievementsToDisplay = new List<string> ();
			if (!AchievementController.hasBeenDamagedByTraps) {
				AchievementController.updateAchievement ("Traps? what traps?", !AchievementController.hasBeenDamagedByTraps);
				achievementsToDisplay.Add ("Traps? what traps?");

				//cycle through all achievements youved gained
				AchievementController.displayAchievements(achievementsToDisplay);

			}
			SoundAdapter.playCollectSound();
			Destroy(this.gameObject);

		}

        if (id == 2 && other.gameObject.tag == "Player") {
            map1.gameObject.SetActive(false);
            map2.gameObject.SetActive(true);
            map3.gameObject.SetActive(false);
            SoundAdapter.playCollectSound();
            Destroy(this.gameObject);
        }

		//see if the box acheivement is achieved
		if (id == 1 && other.gameObject.tag == "Player") {

            map3.gameObject.SetActive(false);
            map2.gameObject.SetActive(false);
            map1.gameObject.SetActive(true);

            //check for the puzzle achievement
            List<string> achievementsToDisplay = new List<string> ();
			if (!AchievementController.hasFailedBoxStage) {
				AchievementController.updateAchievement ("Puzzle Master", !AchievementController.hasFailedBoxStage);
				achievementsToDisplay.Add ("Puzzle Master");
			
				//cycle through all achievements youved gained
				AchievementController.displayAchievements(achievementsToDisplay);

			}
			SoundAdapter.playCollectSound();
			Destroy(this.gameObject);

		}
	}

}
