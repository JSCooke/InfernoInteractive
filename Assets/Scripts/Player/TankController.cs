using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
    public UnityEngine.GameObject tankBase;
    public float acceleration, drag, topSpeed;
    public bool canMove = true;
    
    private float speed;
	private Rigidbody rb;
	private bool doAccelerate, doDecelerate;

    public int maxHealth = 100;
    private int currentHealth;
    public string damagedBy = "Enemy";
    public float lastDamageTime;
    public float iFrameTime = 2;

    public GameObject shield;

    // Use this for initialization
    void Start() {
		rb = GetComponent<Rigidbody> ();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {
		transform.rotation = Quaternion.Euler (
			transform.rotation.eulerAngles.x,
			0,
			transform.rotation.eulerAngles.z);

    }

	void FixedUpdate(){
		if (doAccelerate && !doDecelerate) {
			rb.AddForce (tankBase.transform.forward * acceleration, ForceMode.Acceleration);
		}
		if (doDecelerate && !doAccelerate) {
			rb.AddForce (-tankBase.transform.forward * acceleration, ForceMode.Acceleration);
		}

		//Calculate the horizontal speed of the tank (how much it's 'sliding')
		float horizontalSpeed=Vector3.Project (rb.velocity, tankBase.transform.right).magnitude;
		if (Vector3.Angle (rb.velocity, tankBase.transform.right) > 90) {
			horizontalSpeed *= -1;
		}

		if (Mathf.Abs(horizontalSpeed) > 1) {
			rb.AddForce (tankBase.transform.right * horizontalSpeed * -drag, ForceMode.Acceleration);
		}
	}


	//These are called on Update, so set flags to defer actions until FixedUpdate
    public void accelerate() {
		doAccelerate = true;
    }

    public void decelerate() {
		doDecelerate = true;
    }

	public void stopAccelerate() {
		doAccelerate = false;
	}
	
	public void stopDecelerate() {
		doDecelerate = false;
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == damagedBy) {
            takeDamage(collider.gameObject.GetComponent<BossController>().bodyDamage);
        }
    }

    public void takeDamage(int damage) {
     
        if (shield.gameObject.activeSelf) {
            lastDamageTime = Time.fixedTime;
            shield.SetActive(false);
            return;
        }

        if (Time.fixedTime - lastDamageTime > iFrameTime) {
            lastDamageTime = Time.fixedTime;

            if (damage > currentHealth) {
                damage = currentHealth;
            }

            currentHealth = currentHealth - damage;
            UIAdapter.damagePlayer((float)damage, maxHealth);

        }

    }

}