using UnityEngine;
using System.Collections;
using System;
//Adapted from inScope Studios' health bar tutorial
using UnityEngine.UI;


[Serializable]
public class Stat
{
	public BarScript bar;
	public Text keys;
	public float currentVal;
	public float objectiveCount;
	public float objectiveMax;


	public float CurrentVal {
		get {
			return currentVal;
		}
		set { 
			currentVal = Mathf.Clamp(value, 0, 100);
			bar.Value = currentVal;
		}
	}
		
	//Note that passing negative values in will heal, positive will damage.
	public void damage(float hit){
		currentVal -= hit;
		CurrentVal = currentVal;
	}

	public bool dead() {
		if (bar.Value == 0){
			return true;
		}else{
			return false;
		}
	}

	public bool full() {
		if (bar.Value == 100) {
			return true;
		}else{
			return false;
		}
	}
}
