using UnityEngine;
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class UnitTests {

	[Test]
	public void tankDamage()
	{
		//Create a tank and check if it reduces health correctly when taking damage.
		TankController tank = new TankController();
		tank.maxHealth = 100;
		tank.CurrentHealth = 100;
		Assert.That(tank.CurrentHealth == 100);

		tank.iFrameTime = 0;
		tank.lastDamageTime = 0;
		tank.takeDamage(40);
		Assert.That(tank.CurrentHealth == 60);
	}

	[Test]
	public void bossDamage()
	{
		//Create a slime boss and check if it reduces health correctly when taking damage.
		BossController slimeBoss = new BossController();
		slimeBoss.currentHealth = 100;
		Assert.That(slimeBoss.currentHealth == 100);

		slimeBoss.maxHealth = 100;
		slimeBoss.totalHealth = 100;
		slimeBoss.dead = false;
		slimeBoss.takeDamage(30);
		Assert.That(slimeBoss.currentHealth == 70);
	}

	[Test]
	public void leaderboardScoresAdded()
	{
		//Test if leaderboard adds scores correctly.
		UIAdapter.currentLevel = 1;
		UIAdapter.addScoreToLeader("MIA", 120);

		BossController.Difficulty difficulty = GameData.get<BossController.Difficulty>("difficulty");
		if (difficulty == default(BossController.Difficulty))
		{
			difficulty = BossController.Difficulty.Easy;
		}

		List<LeaderboardEntry> leaders = GameData.get<List<LeaderboardEntry>>("1" + difficulty);
		Assert.That(leaders[0].time == 120);
		Assert.That(leaders[0].player == "MIA");

		//Tests if leaderboard sorts scores correctly.
		UIAdapter.addScoreToLeader("BOO", 5);

		leaders = GameData.get<List<LeaderboardEntry>>("1" + difficulty);
		Assert.That(leaders[0].time == 5);
		Assert.That(leaders[0].player == "BOO");

		Assert.That(leaders[1].time == 120);
		Assert.That(leaders[1].player == "MIA");
	}
}
