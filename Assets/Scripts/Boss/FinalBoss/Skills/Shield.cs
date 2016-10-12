using UnityEngine;
using System.Collections;

public class Shield : SkillController {

    public bool destroyed;
    public float healAmount;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //Amount healed depends on difficulty. 0.02 for easy, 0.03 for medium, 0.04 for hard
        if (healAmount != GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty * -1 / 100) {
            healAmount = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty * -1 / 100;
        }

        healSelf();

        //If both generators hit simulatenously, shield is deactivated
        if (ShieldGenerator.hitCount == 2) {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().randomNextAction();
            this.gameObject.SetActive(false);
            ShieldGenerator.hitCount = 0;
        }
	}

    public Shield() { }

    public Shield(GameObject player, GameObject enemy) : base(player, enemy) { }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "PlayerProjectile") {
            Destroy(collision.gameObject);
        }
    }

    void healSelf() {
        //GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().takeDamage(healAmount);
    }

    
}
