using UnityEngine;
using System.Collections;

public class ddrSpawnerController : MonoBehaviour {
	public UnityEngine.GameObject projectile;
	public int cooldown;
	private int lastShotTime;
	public bool canShoot = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		// check delta time and spawn randomly
		if (canShoot) {
			if (Time.frameCount - lastShotTime > cooldown) {
				lastShotTime = Time.frameCount;
				Instantiate (projectile, transform.position, transform.rotation);
			}
		}

	}
}
