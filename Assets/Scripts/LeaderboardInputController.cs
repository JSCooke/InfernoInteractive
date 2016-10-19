using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeaderboardInputController : MonoBehaviour {

	public Text playerName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Canvas>().enabled && Input.GetKeyDown(KeyCode.Return))
		{
			string player = playerName.text;
			if (player.Trim().Length == 0)
			{
				player = "J&J";
			}

			UIAdapter.addScoreToLeader(player);
			gameObject.GetComponent<Canvas>().enabled = false;
		}
	}
}
