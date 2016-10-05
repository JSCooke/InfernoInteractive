using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
//Adapted from inScope Studios' health bar tutorial
public class BarScript : MonoBehaviour {

	private float fillAmount = 1;
	[SerializeField]
	private float lerpSpeed;
	[SerializeField]
	private Image content;
	[SerializeField]
	private Text valueText; 
	[SerializeField]
	private Color fullColour;
	[SerializeField]
	private Color lowColour;

	public float Value {
		set{
			string[] tmp = valueText.text.Split(':');
			valueText.text = tmp [0] + ": " + Mathf.RoundToInt(value) + "%";
			fillAmount = value/100;
		}
		get{
			return fillAmount * 100;
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	//Potential for optimisation here - rather than checking on update, change the effect of changing value
	void Update () {
		if (fillAmount != content.fillAmount) {
			HandleBar ();
		}
	}

	//Change the size of the coloured image representing the health bar.
	//Call every time fillAmount is changed.
	private void HandleBar() {
		if (fillAmount != content.fillAmount) {
			content.fillAmount = Mathf.Lerp (content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
		content.color = Color.Lerp (lowColour, fullColour, fillAmount);
	}
		
	/**
	 * Sample usage:
	 * A boss has 400hp which goes down to 0, and needs to take 20 damage, and have it represented on a percentage health bar.
	 * Map(20, 0, 400, 0, 100) will return the percentage of health lost,that is:
	 * "map 20hp, on a scale of 0 to 400, to a scale of 0 to 100", and it will return 5.
	 * The health bar returns a value of 95%, and this needs to be mapped back to maximum health.
	 * Map(95, 0, 100, 0, 400) will return the boss's remaining health, that is:
	 * "map 95%, on a scale of 0 to 100, to a scale of 0 to 400", and it will return 380.
	 */
	public static float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
