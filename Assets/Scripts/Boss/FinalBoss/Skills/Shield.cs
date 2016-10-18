using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public bool destroyed;
    private float healAmount = -1f;
    public bool[] hitCount = new bool[2];
    public string damagedBy;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //Amount healed depends on difficulty. 0.02 for easy, 0.03 for medium, 0.04 for hard
        //if (healAmount != GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty * -1 / 100) {
        //    healAmount = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty * -1 / 100;
        //}

        healSelf();

        //If both generators hit simulatenously, shield is deactivated
        if (generatorDestroyed()) {

            this.gameObject.SetActive(false);

            for (int i = 0; i < hitCount.Length; i++) {
                hitCount[i] = false;
            }

            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;
        }
	}

    public Shield() {}

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "PlayerProjectile") {
            Destroy(collision.gameObject);
        }
    }

    void healSelf() {
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().takeDamage(healAmount);
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == damagedBy) {
            Destroy(collider.gameObject);
        }
    }

    public bool generatorDestroyed() {

        for (int i = 0; i < hitCount.Length; i++) {
            if (!hitCount[i]) {
                return false;
            }
        }

        return true;
    }


}
