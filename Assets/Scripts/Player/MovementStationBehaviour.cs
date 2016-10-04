using UnityEngine;
using System.Collections;

public class MovementStationBehaviour : ControlStationBehaviour {
	public UnityEngine.GameObject tank;
    public TankController tankController;
	public UnityEngine.GameObject tankBase;

	public float rotationSpeed;

	void Start(){
		//Auto-find tank references on start
		tankController = GetComponentInParent<TankController> ();
		tank = tankController.gameObject;
		tankBase = tank.transform.Find ("Treads").gameObject;
	}

	public override void keyHeld(bool up, bool left, bool down, bool right){
		if (left && !right) {
			tankBase.transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		}

		if (right && !left) {
			tankBase.transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		}
	}

	public override void keyPressed(bool up, bool left, bool down, bool right){
		if (up) {
			tankController.accelerate ();
		}
		
		if (down) {
			tankController.decelerate ();
		}
	}

	public override void keyReleased(bool up, bool left, bool down, bool right){
		if (up) {
			tankController.stopAccelerate ();
		}
		
		if (down) {
			tankController.stopDecelerate ();
		}
	}
}
