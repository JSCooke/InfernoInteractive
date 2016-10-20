using UnityEngine;
using System.Collections;

public class EMPDialog : ActivateNewDialog {
    public GameObject EMP, enemySpawner, startingEnemies;

	// Use this for initialization
	public override void Start () {
        base.Start();
        //Set the health bar to EMP mode
        UIAdapter.setEMPMode(true);
        UIAdapter.bossVal = 0;
        UIAdapter.damageBoss(0);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public override void OnTriggerEnter(Collider other) {
        //Only activate if the other thing is a tank
        if (other.gameObject.name != "Tank") {
            return;
        }
        base.OnTriggerEnter(other);

        //Spawn the EMP
        EMP.SetActive(true);

        //Enable the enemy spawner
        enemySpawner.SetActive(true);
        //Spawn initial enemies
        startingEnemies.SetActive(true);

        //Show the boss ui
        UIAdapter.setBossUI(true);
    }
}
