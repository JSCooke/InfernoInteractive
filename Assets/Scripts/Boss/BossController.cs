using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public GameObject enemy;
    //public GameObject player;

    //public Transform playerPosition;
    public Transform enemyPosition;

    public float rotationSpeed = 5;
    public int maxLevel = 2;
    public int currentLevel = 0;

    public double maxHealth = 100;
    public double currentHealth = 100;
    public double threshold = 0.5;

    private Vector3 offset = new Vector3(2, 0, 0);
    // Use this for initialization
    void Start () {
        //playerPosition = player.transform;
        enemyPosition = enemy.transform;

        currentHealth = maxHealth;

    }
	
	// Update is called once per frame
	void Update () {
        //enemyPosition.rotation = Quaternion.Slerp(enemyPosition.rotation,
        //Quaternion.LookRotation(playerPosition.position - enemyPosition.position), rotationSpeed * Time.deltaTime);

        if (currentLevel < maxLevel && currentHealth <= maxHealth * threshold)
        {
            GameObject child1 = (GameObject)Instantiate(enemy, this.transform.position + offset, Quaternion.identity);
            child1.transform.localScale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y / 2, this.transform.localScale.z / 2);

            BossController childScript1 = child1.GetComponent<BossController>();
            childScript1.currentLevel = currentLevel + 1;
            childScript1.maxHealth = maxHealth * threshold;
            childScript1.currentHealth = maxHealth * threshold;

            GameObject child2 = (GameObject)Instantiate(enemy, this.transform.position - offset, Quaternion.identity);
            child2.transform.localScale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y / 2, this.transform.localScale.z / 2);

            BossController childScript2 = child2.GetComponent<BossController>();
            childScript2.currentLevel = currentLevel + 1;
            childScript2.maxHealth = maxHealth * threshold;
            childScript2.currentHealth = maxHealth * threshold;

            Destroy(this.gameObject);

        }
    }

    void Awake()
    {

    }
}
