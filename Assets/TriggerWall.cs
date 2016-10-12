using UnityEngine;
using System.Collections;

public class TriggerWall : MonoBehaviour {

	public GameObject countdownBarCanvas;

	void OnTriggerEnter(Collider other){
		countdownBarCanvas.SetActive (true);
	}
}
