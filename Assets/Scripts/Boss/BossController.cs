using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;

    public float rotationSpeed = 5;
    public int maxLevel = 2;
    public int currentLevel = 0;

    public double maxHealth = 100;
    public double currentHealth = 100;
    public double threshold = 0.5;

	public double chargeDuration = 1;
	public double chargeStartTime = 1;

	private float ypos = 0;
	private float time;

	private float verticalSpeed = 0;
	private float horizontalSpeed = 0;
	private float zSpeed = 0;
	private const double gravity = -9.81;
	private bool jumping = false;

    private Vector3 offset = new Vector3(2, 0, 0);

    // Use this for initialization
    void Start () {
       currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
		//enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(this.transform.position - enemy.transform.position), rotationSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.05F);

		if (Time.fixedTime > (chargeStartTime + chargeDuration) && !jumping) {
			chargeStartTime = Time.fixedTime;
			verticalSpeed = (float)2;


			//float temp = this.transform.position.x - player.transform.position.x;
			//horizontalSpeed = this.transform.position.z - player.transform.position.z;
			//horizontalSpeed = Mathf.Sqrt (Mathf.Pow(temp,2) + Mathf.Pow(horizontalSpeed,2));
			//zSpeed = Mathf.Abs( this.transform.position.z - player.transform.position.z);
			//horizontalSpeed = Mathf.Abs(this.transform.position.x - player.transform.position.x);
			jumping = true;
		}

		if (jumping) {
			//this.transform.position.y

			time = (float)Time.deltaTime;
			verticalSpeed = verticalSpeed + (float)gravity * time;
			//horizontalSpeed = horizontalSpeed * (float)Time.deltaTime;
			//zSpeed = zSpeed * (float)Time.deltaTime;

			ypos = ypos + (verticalSpeed*time);
			print (ypos);
			if (ypos < 0) {
				verticalSpeed = 2;
				ypos = 0;
				jumping = false;
			}

			this.transform.Translate (0, ypos, 0);
		
			//if (verticalSpeed <= 0) {
			//	jumping = false;
			//}
		}

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

}
