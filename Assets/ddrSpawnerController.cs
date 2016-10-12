using UnityEngine;
using System.Collections;

public class ddrSpawnerController : MonoBehaviour {
	public UnityEngine.GameObject spawnedObject;
	public int cooldown;
	private int lastSpawnTime;
	public bool canShoot = false;

    //Difficulty affects the number of splits
    public enum Difficulty { Easy = 4, Medium = 3, Hard = 2 };
    public Difficulty difficultyLevel;
    private int difficulty = 2;

    // Use this for initialization
    void Start () {

        //set difficulty level if set in menu
        
        // uncomment when merged to do difficulty

        if (GameData.get<Difficulty>("difficulty") != default(Difficulty))
        {
            difficultyLevel = GameData.get<Difficulty>("difficulty");
            difficulty = (int)GameData.get<Difficulty>("difficulty");
            print("difficulty is " + difficulty);
        }

        print(difficulty);
        print(Random.Range(difficulty-1, difficulty + 1));
        cooldown = Random.Range(difficulty*200, difficulty*500);

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
