using UnityEngine;
using System.Collections;

public class Snare : MonoBehaviour {

    public GameObject wall, player;
    public bool charging = true;
    public float chargeDuration;
    public float startTime = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	    if (charging) {
            chargeAnimation();
        } 

	}

    public Snare() { }

    void chargeAnimation() {

        //chargeParticles.enableEmission = true;

        //(float)this.GetComponent<FinalBossBehaviour>().chargeDuration
        if (UIAdapter.getTimeInSeconds() - startTime > 1) {
            charging = false;
            Instantiate(wall, player.transform.position, Quaternion.identity);

            //chargeParticles.enableEmission = false;
        }
        
    }

}
