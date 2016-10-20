using UnityEngine;
using System.Collections;

public class HollowWall : MonoBehaviour {

    private static float maxHealth = 50f;
    public float baseRotationSpeed = 50f;
    private float rotationSpeed = 50f;
    public float health = 50f;
    public string playerName = "Tank";
    private float damage = 1f;
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
			
        //Rotation speed depends on difficulty. 50 for easy, 100 for medium, 150 for hard
        if (rotationSpeed != (difficulty - 1) * baseRotationSpeed) {
            rotationSpeed = (difficulty - 1) * baseRotationSpeed;
        }

        //Damage over time depends on difficulty. 0.02 for easy, 0.03 for medium, 0.04 for hard
        if (damage != difficulty / 100) {
            damage = difficulty / 100;
        }

        if (health <= 0) {
            Destroy(this.gameObject);
            this.health = maxHealth;
			GameObject.Find("FinalBoss").GetComponent<FinalBossBehaviour>().newAction = true;
        }
			
        //Damage over time while snared
        GameObject.Find(playerName).GetComponent<TankController>().takeDamage(damage);
        transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
    }

}
