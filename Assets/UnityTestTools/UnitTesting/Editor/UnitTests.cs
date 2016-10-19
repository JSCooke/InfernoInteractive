using UnityEngine;
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class UnitTests
{

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
	public void tankIFrame()
	{
		//Check if it health of tank remains the same during player invulnerability time.
		TankController tank = new TankController();
		tank.maxHealth = 100;
		tank.CurrentHealth = 100;
		
		tank.lastDamageTime = 0;
		tank.takeDamage(40);
		Assert.That(tank.CurrentHealth == 100);
	}

	[Test]
	public void bossDamage()
	{
		//Create a boss and check if it reduces health correctly when taking damage.
		BossController boss = new BossController();
		boss.currentHealth = 100;
		Assert.That(boss.currentHealth == 100);

		boss.maxHealth = 100;
		boss.totalHealth = 100;
		boss.dead = false;
		boss.takeDamage(30);
		Assert.That(boss.currentHealth == 70);
	}

	[Test]
	public void bossDead()
	{
		//Create a boss and check if it's status changes to dead when below 1 health.
		BossController boss = new BossController();
		boss.currentHealth = 100;
		Assert.That(boss.dead == false);

		boss.maxHealth = 100;
		boss.totalHealth = 100;
		boss.dead = false;
		boss.takeDamage(110);
		Assert.That(boss.dead == true);
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
	}

	[Test]
	public void leaderboardScoresSorted()
	{
		//Test if leaderboard sorts scores correctly.
		UIAdapter.currentLevel = 1;
		UIAdapter.addScoreToLeader("MIA", 120);
		UIAdapter.addScoreToLeader("BOO", 5);

		BossController.Difficulty difficulty = GameData.get<BossController.Difficulty>("difficulty");
		if (difficulty == default(BossController.Difficulty))
		{
			difficulty = BossController.Difficulty.Easy;
		}

		List<LeaderboardEntry> leaders = GameData.get<List<LeaderboardEntry>>("1" + difficulty);

		Assert.That(leaders[0].time == 5);
		Assert.That(leaders[0].player == "BOO");

		Assert.That(leaders[1].time == 120);
		Assert.That(leaders[1].player == "MIA");
	}

	[Test]
	public void leaderboardScoreSize()
	{
		//Test if leaderboard has the correct number of scores.
		UIAdapter.currentLevel = 1;
		UIAdapter.addScoreToLeader("MIA", 120);
		UIAdapter.addScoreToLeader("BOO", 5);

		BossController.Difficulty difficulty = GameData.get<BossController.Difficulty>("difficulty");
		if (difficulty == default(BossController.Difficulty))
		{
			difficulty = BossController.Difficulty.Easy;
		}

		List<LeaderboardEntry> leaders = GameData.get<List<LeaderboardEntry>>("1" + difficulty);

		Assert.That(leaders.Count == 2);
	}
}
