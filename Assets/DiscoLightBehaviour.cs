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
	
		if (Time.frameCount % 100 == 0) {
			transform.GetComponent<Light> ().enabled = true;
		}
		else if (Time.frameCount % 50 == 0) {
			transform.GetComponent<Light> ().enabled = false;
		}
			transform.Rotate (new Vector3 (1.0f, 0f, 1.0f));
			//var euler = transform.eulerAngles;
			//euler.z = Random.Range (-70f, 70f);
			//euler.x= Random.Range (-70f, 70f);
			//transform.eulerAngles = euler;

	}
}
