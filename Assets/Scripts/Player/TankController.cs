using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
    public UnityEngine.GameObject tankBase;
    public float drag, angleLimit;
    public bool canMove = true;
    
    private float speed;
	private Rigidbody rb;
    private Wheel_Control_CS wheelController;

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
        wheelController = GetComponentInChildren<Wheel_Control_CS>();
    }

    // Update is called once per frame
    void Update() {
    }

	void FixedUpdate(){

        //Calculate the horizontal speed of the tank (how much it's 'sliding') and apply drag in that direction
        float horizontalSpeed = Vector3.Project(rb.velocity, tankBase.transform.right).magnitude;
        if (Vector3.Angle(rb.velocity, tankBase.transform.right) > 90) {
            horizontalSpeed *= -1;
        }

        if (Mathf.Abs(horizontalSpeed) > 1) {
            rb.AddForce(tankBase.transform.right * horizontalSpeed * -drag, ForceMode.Acceleration);
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

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == damagedBy) {
            takeDamage(collider.gameObject.GetComponent<BossController>().bodyDamage);
        }
    }

    public void takeDamage(int damage) {

        //fail the no damage achievement
		AchievementController.hasBeenDamaged = true;
        AchievementController.hasBeenDamagedL3 = true;

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