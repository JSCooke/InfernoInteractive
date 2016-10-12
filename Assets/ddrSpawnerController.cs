using UnityEngine;
using System.Collections;

public class ddrSpawnerController : MonoBehaviour {
	public UnityEngine.GameObject spawnedObject;
	public int cooldown;
	private int lastSpawnTime;
	public bool canShoot = false;

    //Difficulty affects the number of splits
    private int difficulty = 2;

    // Use this for initialization
    void Start () {

        //set difficulty level if set in menu
        
        // uncomment when merged to do difficulty

		if (GameData.get<BossController.Difficulty>("difficulty") != default(BossController.Difficulty))
        {
			difficulty = (int)GameData.get<BossController.Difficulty>("difficulty");
        }

		if (difficulty == 2) {
			cooldown = Random.Range (cooldown, difficulty * 800);
		} else {
			cooldown = Random.Range (cooldown, difficulty * 500);
		}
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
