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

	public float ObjectiveCount {
		get {
			return objectiveCount;
		}
		set {
			float newValue = Mathf.Clamp (value, 0, objectiveMax);
			string[] tmp = keys.text.Split(new Char [] {' ' , '/' });
			keys.text = tmp [0] + " " + newValue + "/" + objectiveMax; 
			objectiveCount = newValue;
		}
	}
}
