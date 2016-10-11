using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
    public UnityEngine.GameObject tankBase;
    public float acceleration, drag, topSpeed, angleLimit;
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
		shield = transform.Find ("Shield").gameObject;
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

			//Clamping y vector
			Vector3 movement = tankBase.transform.forward;
			movement.y = Mathf.Clamp (movement.y, -0.5f, 0.1f);
			rb.AddForce (movement * acceleration, ForceMode.Acceleration);
		}
		if (doDecelerate && !doAccelerate) {
			rb.AddForce (-tankBase.transform.forward * acceleration, ForceMode.Acceleration);
		}

		rb.velocity = rb.velocity.normalized * Mathf.Min (topSpeed, rb.velocity.magnitude);

		//Calculate the horizontal speed of the tank (how much it's 'sliding') and apply drag in that direction
		float horizontalSpeed=Vector3.Project (rb.velocity, tankBase.transform.right).magnitude;
		if (Vector3.Angle (rb.velocity, tankBase.transform.right) > 90) {
			horizontalSpeed *= -1;
		}

		if (Mathf.Abs(horizontalSpeed) > 1) {
			rb.AddForce (tankBase.transform.right * horizontalSpeed * -drag, ForceMode.Acceleration);
		}

        //check if angle with ground plane is >45 degrees, clamp rotation to between -45 and 45 degrees with ground
        // in both x and z axes
        if (transform.rotation.eulerAngles.x > angleLimit && transform.rotation.eulerAngles.x < 360 - angleLimit) {
            if (transform.rotation.eulerAngles.x < 180) {
                transform.rotation = Quaternion.Euler(
                    angleLimit,
                    transform.rotation.eulerAngles.y,
                    transform.rotation.eulerAngles.z);
            } else {
                transform.rotation = Quaternion.Euler(
                    360 - angleLimit,
                    transform.rotation.eulerAngles.y,
                    transform.rotation.eulerAngles.z);
            }
        }

        if (transform.rotation.eulerAngles.z > angleLimit && transform.rotation.eulerAngles.z < 360 - angleLimit) {
            if (transform.rotation.eulerAngles.z < 180) {
                transform.rotation = Quaternion.Euler(
                    transform.rotation.eulerAngles.x,
                    transform.rotation.eulerAngles.y,
                    angleLimit);
            } else {
                transform.rotation = Quaternion.Euler(
                    transform.rotation.eulerAngles.x,
                    transform.rotation.eulerAngles.y,
                    360 - angleLimit);
            }
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

        //fail the no damage achievement
		AchievementController.hasBeenDamaged = true;

        if (shield.gameObject.activeSelf) {
            lastDamageTime = Time.fixedTime;
            shield.SetActive(false);
			SoundAdapter.playShieldDownSound ();
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