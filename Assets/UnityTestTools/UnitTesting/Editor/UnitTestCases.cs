using UnityEngine;
using NUnit.Framework;
using UnityEditor;
using System;
using System.Collections.Generic;

[TestFixture]
public class UnitTestCases
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
		tank.iFrameTime = 2;

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
		BossController.Difficulty difficulty = GameData.get<BossController.Difficulty>("difficulty");
		if (difficulty == default(BossController.Difficulty))
		{
			difficulty = BossController.Difficulty.Easy;
		}

		GameData.put("1" + difficulty, null);

		UIAdapter.currentLevel = 1;
		UIAdapter.points = 120;
		UIAdapter.addScoreToLeader("MIA");

		List<LeaderboardEntry> leaders = GameData.get<List<LeaderboardEntry>>("1" + difficulty);
		Assert.That(leaders[0].score == 120);
		Assert.That(leaders[0].player == "MIA");
	}

	[Test]
	public void leaderboardScoresSorted()
	{
		//Test if leaderboard sorts scores correctly.
		BossController.Difficulty difficulty = GameData.get<BossController.Difficulty>("difficulty");
		if (difficulty == default(BossController.Difficulty))
		{
			difficulty = BossController.Difficulty.Easy;
		}

		GameData.put("1" + difficulty, null);

		UIAdapter.currentLevel = 1;
		UIAdapter.points = 5;
		UIAdapter.addScoreToLeader("BOO");
		UIAdapter.points = 120;
		UIAdapter.addScoreToLeader("MIA");

		List<LeaderboardEntry> leaders = GameData.get<List<LeaderboardEntry>>("1" + difficulty);

		Assert.That(leaders[0].score == 120);
		Assert.That(leaders[0].player == "MIA");

		Assert.That(leaders[1].score == 5);
		Assert.That(leaders[1].player == "BOO");
	}
}
