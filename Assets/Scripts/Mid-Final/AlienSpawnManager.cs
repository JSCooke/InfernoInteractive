using UnityEngine;
using System.Collections;

public class AlienSpawnManager : MonoBehaviour {

    public TankController tank;
    public GameObject enemy;
    public float spawnTime = 5f;
    public Transform[] spawnPoints;

    float easy = 20f;
    float med = 15f;
    float hard = 10f;



    // Use this for initialization
    void Start () {
        spawnPoints = GetComponentsInChildren<Transform>();
        int dif = (int)GameData.get<BossController.Difficulty>("difficulty");

        switch (dif)
        {
            case 2:
                spawnTime = easy;
                break;
            case 3:
                spawnTime = med;
                break;
            case 4:
                spawnTime = hard;
                break;
        }    

        //repeat method,start time, time before call again
        InvokeRepeating("Spawn", 0, spawnTime);
	
	}

    void OnTriggerEnter(Collider other) {
        print(other);
    }

    void Spawn()
    {
        //if tank health is not 0 then

        int spawnPointIndex = Random.RandomRange(0, spawnPoints.Length);
        
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    public void stopSpawn()
    {
        CancelInvoke();
    }
	
	
}
