using UnityEngine;
using System.Collections;

public class TriggerWall : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		print("TRIGGERED");
	}
}
