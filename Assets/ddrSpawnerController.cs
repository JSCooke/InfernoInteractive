using UnityEngine;
using System.Collections;

public class ddrSpawnerController : MonoBehaviour {
	public UnityEngine.GameObject spawnedObject;
	public int cooldown;
	private int lastSpawnTime;
	public bool canShoot = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		// check delta time and spawn
		//spawn differently for different difficulties
		if (canShoot) {
			if (Time.frameCount - lastSpawnTime > cooldown) {
                lastSpawnTime = Time.frameCount;

				Instantiate (spawnedObject, transform.position, transform.rotation);
			}
		}

	}
}
