using UnityEngine;
using System.Collections;

public class Shield : Skill {

    public GameObject shieldGenerator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (shieldGenerator) {
            //print("deactivated");
            chargeParticles.enableEmission = false;
            performSkill = false;
            enemy.GetComponent<FinalBossBehaviour>().randomNextAction();
        }
	}

    public Shield() { }

    public Shield(GameObject player, GameObject enemy) : base(player, enemy) { }

    void OnCollisionEnter(Collision collision) {
        if (performSkill) {
            if (collision.gameObject.tag == "PlayerProjectile") {
                Destroy(collision.gameObject);
            }
        }
    }

    
}
