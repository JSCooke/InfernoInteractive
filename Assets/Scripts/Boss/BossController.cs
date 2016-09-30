using UnityEngine;
using System.Collections;

public class BossController : Damageable {

    public GameObject enemy;
    public GameObject player;

    public float rotationSpeed = 5;
    public int maxLevel = 2;
    public int currentLevel = 0;

    public double threshold = 0.5;

	public double chargeDuration = 2;
	public double chargeStartTime = 10;

	//public RigidBody rb;

	//private float ypos = 0;
	//private float time;

    //private float verticalSpeed = 0;
    //private float horizontalSpeed = 0;
    //private float zSpeed = 0;
    //private const double gravity = -9.81;
    //private bool jumping = false;

    private bool targetAcquired = false;
    private Vector3 playerPosition;
	private bool randomMovement = true;

    private Vector3 offset = new Vector3(2, 0, 0);

    // Use this for initialization
    void Start () {
       currentHealth = maxHealth;
		maxHealth = currentHealth;
		//rb = GetComponent<RigidBody> (); 
    }

	// Update is called once per frame
	void Update () {

		if (!randomMovement) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (this.transform.position - player.transform.position), rotationSpeed * Time.deltaTime);
		}

		//Attack when ready and not already attacking
        if (!targetAcquired && Time.fixedTime > (chargeStartTime + chargeDuration)) {
            targetAcquired = true;
            playerPosition = player.transform.position;
			randomMovement = false;
            //verticalSpeed = (float)2;
        }

		if (targetAcquired) {
			transform.position = Vector3.MoveTowards (transform.position, playerPosition, 0.15F);
            
			if (transform.position == playerPosition) {
				targetAcquired = false;
				chargeStartTime = Time.fixedTime;
				randomMovement = true;
			}
            
		} 

        if (currentLevel < maxLevel && currentHealth <= maxHealth * threshold){
            GameObject child1 = (GameObject)Instantiate(enemy, this.transform.position + offset, Quaternion.identity);
            child1.transform.localScale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y / 2, this.transform.localScale.z / 2);

            BossController childScript1 = child1.GetComponent<BossController>();
            childScript1.currentLevel = currentLevel + 1;
			childScript1.maxHealth = (int)(maxHealth * threshold);
			childScript1.currentHealth = (int)(maxHealth * threshold);

            GameObject child2 = (GameObject)Instantiate(enemy, this.transform.position - offset, Quaternion.identity);
            child2.transform.localScale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y / 2, this.transform.localScale.z / 2);

            BossController childScript2 = child2.GetComponent<BossController>();
            childScript2.currentLevel = currentLevel + 1;
			childScript2.maxHealth = (int)(maxHealth * threshold);
			childScript2.currentHealth = (int)(maxHealth * threshold);

            Destroy(this.gameObject);

        }
    }

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "Player") {
			targetAcquired = false;
			chargeStartTime = Time.fixedTime;
		}
	}

	void OnTriggerStay(Collider collider) {

		if (collider.gameObject.tag == "Player") {
			targetAcquired = false;
			chargeStartTime = Time.fixedTime;
		}
	}


}


//	//float temp = this.transform.position.x - player.transform.position.x;
//	//horizontalSpeed = this.transform.position.z - player.transform.position.z;
//	//horizontalSpeed = Mathf.Sqrt (Mathf.Pow(temp,2) + Mathf.Pow(horizontalSpeed,2));
//	//zSpeed = Mathf.Abs( this.transform.position.z - player.transform.position.z);
//	//horizontalSpeed = Mathf.Abs(this.transform.position.x - player.transform.position.x);
//	//jumping = true;
//}

//if (jumping) {
//	//this.transform.position.y

//	//time = (float)Time.deltaTime;
//	//verticalSpeed = verticalSpeed + (float)gravity * time;
//	//horizontalSpeed = horizontalSpeed * (float)Time.deltaTime;
//	//zSpeed = zSpeed * (float)Time.deltaTime;

//	ypos = ypos + (verticalSpeed*time);
//	print (ypos);
//	if (ypos < 0) {
//		verticalSpeed = 2;
//		ypos = 0;
//		jumping = false;
//	}

//	this.transform.Translate (0, ypos, 0);

//	//if (verticalSpeed <= 0) {
//	//	jumping = false;
//	//}
//}