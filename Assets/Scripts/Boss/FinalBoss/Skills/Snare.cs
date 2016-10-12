using UnityEngine;
using System.Collections;

public class Snare : SkillController {

    public GameObject wall;
    public bool charging = true;
    public float chargeDuration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (charging) {
            StartCoroutine(chargeAnimation());
        } else {
            Instantiate(wall, player.transform.position, Quaternion.identity);
        }
	}

    public Snare() { }

    public Snare(GameObject player, GameObject enemy) : base(player, enemy) {}

    IEnumerator chargeAnimation() {
        chargeParticles.enableEmission = true;



        //Done charging
        yield return new WaitForSeconds(chargeDuration);

        chargeParticles.enableEmission = false;
        charging = false;
    }
}
