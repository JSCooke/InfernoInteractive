using UnityEngine;
using NUnit.Framework;
using System;

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
}
