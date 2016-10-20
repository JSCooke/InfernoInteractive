using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public bool destroyed;
    private float healAmount = -0.02f;
    public bool[] hitCount = new bool[2];
    public string damagedBy;
	private int difficulty = 2;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

		if (GameData.get<BossController.Difficulty>("difficulty") != default(BossController.Difficulty))
		{
			difficulty = (int)GameData.get<BossController.Difficulty>("difficulty");
		}

        //Amount healed depends on difficulty. 0.02 for easy, 0.03 for medium, 0.04 for hard
		if (healAmount != (float)(difficulty * -1) / (float)100) {
			healAmount = (float)(difficulty * -1) / (float)100;
        }

        healSelf();

        //If both generators hit simulatenously, shield is deactivated
        if (generatorDestroyed()) {
			SoundAdapter.playShieldDownSound ();
			GameObject.Find("FinalBoss").GetComponent<FinalBossBehaviour>().newAction = true;
			Destroy (this.gameObject);
        }
	}

    public Shield() {}

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "PlayerProjectile") {
            Destroy(collision.gameObject);
        }
    }

    void healSelf() {
		GameObject.Find("FinalBoss").GetComponent<BossController>().takeDamage(healAmount);
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
