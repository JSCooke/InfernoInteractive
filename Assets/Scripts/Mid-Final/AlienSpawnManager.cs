using UnityEngine;
using System.Collections;

public class AlienSpawnManager : MonoBehaviour {

    public TankController tank;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    // Use this for initialization
    void Start () {

        //repeat method,start time, time before call again
        InvokeRepeating("Spawn", 0, spawnTime);
	
	}

    void Spawn()
    {
        //if tank health is not 0 then

        int spawnPointIndex = Random.RandomRange(0, spawnPoints.Length);


        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
	
	
}
