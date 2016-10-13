using UnityEngine;
using System.Collections;

public class HollowWall : MonoBehaviour {

    private static float maxHealth = 50f;
    public float baseRotationSpeed;
    private float rotationSpeed = 50f;
    public float health = 50f;
    public string playerName = "Tank";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Rotation speed depends on difficulty. 50 for easy, 100 for medium, 150 for hard
        //if (rotationSpeed != (GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty - 1) * baseRotationSpeed) {
        //    rotationSpeed = (GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty - 1) * baseRotationSpeed;
        //}

        if (health <= 0) {
            //GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().randomNextAction();
            Destroy(this.gameObject);
            this.health = maxHealth;
            GameObject.Find("Snare").GetComponent<Snare>().charging = true;
        }

        ////Damage over time while snared
        //GameObject.Find(playerName).GetComponent<TankController>().takeDamage((float)GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty / 100);
        transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
    }

}
