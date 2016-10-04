using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public KeyCode action, moveUp, moveLeft, moveDown, moveRight;
	public float moveSpeed, heightOffset;
	public bool enableMovement = true;

	private GameObject currentControlStation;
	private ControlStationController currentControlStationController;

	private bool attachedToControlStation = false;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
		resetPosition ();

	}

	void movement(){
		if (Input.GetKeyDown (action)) {
			toggleControl();
		}

		if (!attachedToControlStation && enableMovement) {
			//Move up
			if (Input.GetKey (moveUp) && !Input.GetKey (moveDown)) {
				transform.Translate (0, 0, moveSpeed * Time.deltaTime);
			}
			//Move down
			if (Input.GetKey (moveDown) && !Input.GetKey (moveUp)) {
				transform.Translate (0, 0, -moveSpeed * Time.deltaTime);
			}

			//Move left
			if (Input.GetKey (moveLeft) && !Input.GetKey (moveRight)) {
				transform.Translate (-moveSpeed * Time.deltaTime, 0, 0);
			}
			//Move right
			if (Input.GetKey (moveRight) && !Input.GetKey (moveLeft)) {
				transform.Translate (moveSpeed * Time.deltaTime, 0, 0);
			}
		} else if (attachedToControlStation && currentControlStationController!=null && currentControlStationController.behaviour!=null) {
			//If currently attacked to a control station, send the inputs to be processed by the behaviour script
			currentControlStationController.behaviour.keyPressed(
				Input.GetKeyDown(moveUp), 
				Input.GetKeyDown(moveLeft), 
				Input.GetKeyDown(moveDown), 
				Input.GetKeyDown(moveRight));

			currentControlStationController.behaviour.keyHeld(
				Input.GetKey(moveUp), 
				Input.GetKey(moveLeft), 
				Input.GetKey(moveDown), 
				Input.GetKey(moveRight));

			currentControlStationController.behaviour.keyReleased(
				Input.GetKeyUp(moveUp), 
				Input.GetKeyUp(moveLeft), 
				Input.GetKeyUp(moveDown), 
				Input.GetKeyUp(moveRight));
		}

	}

	void resetPosition(){
		transform.localRotation = new Quaternion ();
		if (attachedToControlStation) {
			transform.position = currentControlStation.transform.position + new Vector3 (0, heightOffset, 0);
		}
	}

	public void detach(){
		attachedToControlStation = false;
		//Unfreeze x and z positions
		rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
		if (currentControlStationController != null) {
			currentControlStationController.detachPlayer ();
		}
	}

	void toggleControl(){
		if (attachedToControlStation) {
			attachedToControlStation = false;

			//Unfreeze x and z positions
			rb.constraints=RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
			currentControlStationController.detachPlayer ();
		} else {
			if (currentControlStationController != null) {
				attachedToControlStation = true;

				//Freeze position and rotation
				rb.constraints=	RigidbodyConstraints.FreezeAll;
				currentControlStationController.attachPlayer (this.gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "ControlStation") {
			currentControlStation = other.gameObject;
			currentControlStationController = other.GetComponent<ControlStationController> ();
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject==currentControlStation){
			currentControlStation=null;
			currentControlStationController=null;
		}
	}
}
