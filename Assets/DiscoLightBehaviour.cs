using UnityEngine;
using System.Collections;

public class DiscoLightBehaviour : MonoBehaviour {


	// Use this for initialization
	void Start () {
		//set a random color
		transform.GetComponent<Light> ().color = Random.ColorHSV (0f, 1f, 1f, 1f, 0.5f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.frameCount % 15 == 0) {
			var euler = transform.eulerAngles;
			euler.z = Random.Range (-70f, 70f);
			euler.x= Random.Range (-70f, 70f);
			transform.eulerAngles = euler;
		}

	}
}
