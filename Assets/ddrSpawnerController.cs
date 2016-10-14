using UnityEngine;
using System.Collections;

public class ddrSpawnerController : MonoBehaviour {
	public UnityEngine.GameObject spawnedObject;
	public int cooldown;
	private int lastSpawnTime;
	private int startTime;
	public bool canShoot = false;
	public bool firstShot = false;

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

		//changing the values so that hard = a lower number so that monsters spawn more often
		if (difficulty < 3) {
			difficulty = 4;
		} else if (difficulty > 3) {
			difficulty = 2;
		}

			print (difficulty);
		cooldown = Random.Range (cooldown-1, cooldown + (difficulty*5));

    }
	
	// Update is called once per frame
	void Update () {
	

		// check delta time and spawn
		//spawn differently for different difficulties
		if (canShoot) {

			if (!firstShot) {
				lastSpawnTime = (UIAdapter.getTime() [0] * 60 + UIAdapter.getTime () [1]);
				firstShot = true;
			}
			if ((UIAdapter.getTime() [0]*60 + UIAdapter.getTime() [1]) - lastSpawnTime > cooldown) {
				lastSpawnTime = (UIAdapter.getTime() [0] * 60 + UIAdapter.getTime () [1]);

				Instantiate (spawnedObject, transform.position, transform.rotation);
			}
		}

	}
}
