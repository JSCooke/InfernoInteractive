using UnityEngine;
using System.Collections;

public class HollowWall : MonoBehaviour {

    private static float maxHealth = 50f;
    public float baseRotationSpeed = 50f;
    private float rotationSpeed = 50f;
    public float health = 50f;
    public string playerName = "Tank";
    private float damage = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Rotation speed depends on difficulty. 50 for easy, 100 for medium, 150 for hard
        //if (rotationSpeed != (GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty - 1) * baseRotationSpeed) {
        //    rotationSpeed = (GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty - 1) * baseRotationSpeed;
        //}

        //Damage over time depends on difficulty. 0.02 for easy, 0.03 for medium, 0.04 for hard
        if (damage != (GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty / 100)) {
            damage = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty / 100;
        }

        if (health <= 0) {
            Destroy(this.gameObject);
            this.health = maxHealth;
			GameObject.Find("FinalBoss").GetComponent<FinalBossBehaviour>().newAction = true;
        }

        damage = 0.02f;
        //Damage over time while snared
        GameObject.Find(playerName).GetComponent<TankController>().takeDamage(damage);
        transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
    }

}
