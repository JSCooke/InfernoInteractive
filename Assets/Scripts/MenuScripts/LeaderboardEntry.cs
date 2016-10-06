using UnityEngine;
using System.Collections;

public class LeaderboardEntry {

	public string player { get; set; }
	public int time { get; set; } // in seconds

	public LeaderboardEntry(string player, int time)
	{
		this.player = player;
		this.time = time;
	}

	public bool lessThan(int otherTime)
	{
		return time < otherTime;
	}

}
