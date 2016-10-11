using UnityEngine;
using System.Collections;

public class DiscoLightController : MonoBehaviour {

	public UnityEngine.GameObject spawnedObject;
	public int numOfLights = 15;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startDisco(){

		for (int i = 0; i < numOfLights; i++) {
			Vector3 temp = transform.position;
			temp.y = 20f;
			Instantiate (spawnedObject, temp, Random.rotation);
		}
	}
}
