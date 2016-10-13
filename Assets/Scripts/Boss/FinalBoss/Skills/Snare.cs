using UnityEngine;
using System.Collections;

public class Snare : SkillController {

    public GameObject wall;
    public bool charging = true;
    public float chargeDuration;
    private float startTime;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	    if (charging) {
            charging = false;
            startTime = UIAdapter.getTimeInSeconds();
            chargeAnimation();
        }
	}

    public Snare() { }

    public Snare(GameObject player, GameObject enemy) : base(player, enemy) {}

    void chargeAnimation() {

        //chargeParticles.enableEmission = true;

        //(float)this.GetComponent<FinalBossBehaviour>().chargeDuration
        if (UIAdapter.getTimeInSeconds() - startTime > 3) {
            this.gameObject.SetActive(false);
            Instantiate(wall, player.transform.position, Quaternion.identity);

            //chargeParticles.enableEmission = false;
        }

        
    }
}
