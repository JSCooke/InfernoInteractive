using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ddrController : MonoBehaviour {

	public GameObject[] spawners;
	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("ddrSpawner");
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Tank")
		{
			print ("In here");
			foreach (GameObject spawner in spawners) {
				spawner.GetComponent<ddrSpawnerController> ().canShoot = true;
                other.transform.position = transform.position;
                other.GetComponent<TankController>().canMove = false;
                other.attachedRigidbody.velocity = new Vector3(0, 0, 0);
            }
		}

	}

}
