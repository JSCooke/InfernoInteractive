using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public KeyCode action, moveUp, moveLeft, moveDown, moveRight;
	public float moveSpeed;

	private GameObject currentControlStation;
	private ControlStationController currentControlStationController;

	private bool attachedToControlStation = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
	}

	void movement(){
		if (Input.GetKeyDown (action)) {
			toggleControl();
		}

		if (!attachedToControlStation) {
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
		} else {
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

	void toggleControl(){
		if (attachedToControlStation) {
			attachedToControlStation = false;
			currentControlStationController.detachPlayer ();
		} else {
			if (currentControlStationController != null) {
				currentControlStationController.attachPlayer (this.gameObject);
				attachedToControlStation = true;
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
