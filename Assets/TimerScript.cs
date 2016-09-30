using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
	//Code adapted from http://answers.unity3d.com/questions/132204/countdowncountup-timer.html
	public Text text;
	private float millis = 0.0f;
	private float seconds = 0.0f;
	private float minutes = 0.0f;

	public void Update(){
		millis += Time.deltaTime*1000;
		if (millis > 60) {
			seconds += 1;
			millis = 0;
		}
		if (seconds > 60) {
			minutes += 1;
			seconds = 0;
		}
		text.text = Mathf.RoundToInt(minutes).ToString("D2") + ":" + Mathf.RoundToInt(seconds).ToString("D2") + ":" + Mathf.RoundToInt(millis).ToString("D2");
	}
}
