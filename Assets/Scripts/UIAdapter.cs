using System;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	[Serializable]
	public class UIAdapter
	{
		public BarScript player;
		public float playerVal;
		public float PlayerVal {
			get {
				return playerVal;
			}
			set { 
				playerVal = Mathf.Clamp(value, 0, 100);
				player.Value = playerVal;
			}
		}

		public BarScript boss;
		public float bossVal;
		public float BossVal {
			get {
				return bossVal;
			}
			set { 
				bossVal = Mathf.Clamp(value, 0, 100);
				boss.Value = bossVal;
			}
		}
		public Animator achievementAnimator;
		public UIAdapter ()
		{
		}
		//Reduces (negative increases) the player's health by the input percentage.
		//Returns the remaining hp of the player.
		public float damagePlayer(float hp){
			playerVal -= hp;
			PlayerVal = playerVal;
			return PlayerVal;
		}
		//Reduces (negative increases) the boss's health by the input percentage.
		//Returns the remaining hp of the boss.
		public float damageBoss(float hp){
			bossVal -= hp;
			BossVal = bossVal;
			return BossVal;
		}
		//Causes an achievement box to pop up
		//Add paramters to specify details about the achievement.
		public void achieve(){
			achievementAnimator.SetTrigger ("Achievement");
		}
		public bool playerDead() {
			if (PlayerVal == 0){
				return true;
			}else{
				return false;
			}
		}
		public bool bossDead() {
			if (BossVal == 0){
				return true;
			}else{
				return false;
			}
		}
	}
}

