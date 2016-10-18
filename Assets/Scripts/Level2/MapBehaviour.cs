using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapBehaviour : MonoBehaviour {

	public int id;
	public float rotateSpeed = 1;
	public float translateSpeed = 1;
	public float translateAmplitude = 1;

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

	public void OnTriggerEnter()
	{
		// TODO "pick up" map

		if (id == 3) // last map to collect
		{
			UIAdapter.win();
		}

		//see if the box acheivement is achieved
		if (id == 1) {
			List<string> achievementsToDisplay = new List<string> ();
			if (!AchievementController.hasFailedBoxStage) {
				AchievementController.updateAchievement ("Puzzle Master", !AchievementController.hasFailedBoxStage);
				achievementsToDisplay.Add ("Puzzle Master");
			
				//cycle through all achievements youved gained
				AchievementController.displayAchievements(achievementsToDisplay);
			}

		}
	}

}
