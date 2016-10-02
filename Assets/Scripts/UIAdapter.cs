using System;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	[Serializable]
	public class UIAdapter
	{
		public Stat player;
		public Stat boss;
		public Animator achievementAnimator;
		public UIAdapter ()
		{
		}
		//Reduces (negative increases) the player's health by the input percentage.
		//Returns the remaining hp of the player.
		public float damagePlayer(float hp){
			player.damage (hp);
			return player.CurrentVal;
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
		public bool playerDead() {
			if (player.CurrentVal == 0){
				return true;
			}else{
				return false;
			}
		}
		public bool bossDead() {
			if (boss.CurrentVal == 0){
				return true;
			}else{
				return false;
			}
		}
	}
}

