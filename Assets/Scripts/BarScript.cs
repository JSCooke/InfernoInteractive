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

	//This is a general function, and can be adapted. value/inMax will cut the mustard in 90% of our cases
	public static float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
