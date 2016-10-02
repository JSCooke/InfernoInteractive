using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
    public GameObject tankBase;
    public float acceleration, drag, topSpeed;
    public bool canMove = true;

    private float speed;
	private Rigidbody rb;
	private bool doAccelerate, doDecelerate;

    // Use this for initialization
    void Start() {
		rb = GetComponent<Rigidbody> ();
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

}
