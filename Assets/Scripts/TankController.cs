using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
    public GameObject tankBase;
    public float acceleration, drag, topSpeed;

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


		if(Vector3.Angle(tankBase.transform.forward, rb.velocity)<90){
			//If angle between treads' forward vector and velocity is <90 degrees, assume forward movement
			//Set all velocity to be in direction of treads
			rb.velocity = new Vector3 (tankBase.transform.forward.x, Mathf.Min (0, tankBase.transform.forward.y), tankBase.transform.forward.z) * rb.velocity.magnitude;
		}else{
			//If angle between treads' forward vector and velocity is >90 degrees, assume backwards movement
			//Set all velocity to be in direction of treads
			rb.velocity = new Vector3 (tankBase.transform.forward.x, Mathf.Min (0, tankBase.transform.forward.y), tankBase.transform.forward.z) * -rb.velocity.magnitude;
		}
	}

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
