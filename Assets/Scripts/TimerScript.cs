using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
	//Code adapted from http://answers.unity3d.com/questions/132204/countdowncountup-timer.html
	public Text text;
	private float seconds = 0.0f;
	private float minutes = 0.0f;
	public bool stop = true;

	public bool Stop {
		get {
			return stop;
		}
		set {
			stop = value;
		}
	}

	public void Start(){
		stop = false;
	}

	public void Update(){
		if (!stop) {
			if (seconds >= 59) {
				minutes += 1;
				seconds = 0;
			}
			text.text = Mathf.RoundToInt (minutes).ToString ("D2") + ":" + Mathf.RoundToInt (seconds).ToString ("D2");
			seconds += Time.deltaTime;
		}
	}
	public float[] getTime(){
		return new float[] { minutes, seconds };
	}
}
