using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class scoreboard : MonoBehaviour {

	public int level;

    public Text[] EasyNames;
    public Text[] EasyTimes;
    public Text[] MedNames;
    public Text[] MedTimes;
    public Text[] HardNames;
    public Text[] HardTimes;

    void Start () {
		List<LeaderboardEntry> easy = GameData.get<List<LeaderboardEntry>>(level.ToString() + "Easy");
		List<LeaderboardEntry> medium = GameData.get<List<LeaderboardEntry>>(level.ToString() + "Medium");
		List<LeaderboardEntry> hard = GameData.get<List<LeaderboardEntry>>(level.ToString() + "Hard");
		
		if (easy == null) { // initialise the lists if they are empty
			easy = new List<LeaderboardEntry>();
		}
		if (medium == null) {
			medium = new List<LeaderboardEntry>();
		}
		if (hard == null) {
			hard = new List<LeaderboardEntry>();
		}

		for (int i = 0; i < 6; i++) {
			if (i >= easy.Count) {
				EasyNames[i].text = "----";
				EasyTimes[i].text = Format(-1);
			} else {
				EasyNames[i].text = easy[i].player;
				EasyTimes[i].text = Format(easy[i].time);
			}
			if (i >= medium.Count) {
				MedNames[i].text = "----";
				MedTimes[i].text = Format(-1);
			} else {
				MedNames[i].text = medium[i].player;
				MedTimes[i].text = Format(medium[i].time);
			}
			if (i >= hard.Count) {
				HardNames[i].text = "----";
				HardTimes[i].text = Format(-1);
			} else {
				HardNames[i].text = hard[i].player;
				HardTimes[i].text = Format(hard[i].time);
			}
		}
	}

	public string Format(int time) {
		if (time != -1) {
			int sec = time % 60;
			int min = (time - sec) / 60;
			string seconds = sec.ToString();
			if (seconds.Length == 1)
			{
				seconds = "0" + seconds;
			}
			return min.ToString() + ":" + seconds;
		}
		return "--:--";
	}
}
