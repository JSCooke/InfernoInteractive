using System;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	[Serializable]
	public class UIAdapter
	{
		public Stat health;
		public Stat boss;
		public Animator achievementAnimator;
		public Image achievementBox;
		public UIAdapter ()
		{
			achievementAnimator = achievementBox.GetComponent<Animator>();
		}
		//Reduces (negative increases) the player's health by the input percentage.
		//Returns the remaining hp of the player.
		public float damagePlayer(float hp){
			health.damage (hp);
			return health.CurrentVal;
		}
		//Reduces (negative increases) the boss's health by the input percentage.
		//Returns the remaining hp of the boss.
		public float damageBoss(float hp){
			boss.damage (hp);
			return boss.CurrentVal;
		}
		//Causes an achievement box to pop up
		//Add paramters to specify details about the achievement.
		public void achieve(){
			achievementAnimator.SetTrigger ("Achievement");
		}
	}
}

