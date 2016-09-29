using UnityEngine;
using System.Collections;

public class MovementStationBehaviour : ControlStationBehaviour {
	public GameObject tank;
    public TankController tankController;
	public GameObject tankBase;

	public float rotationSpeed;

	public override void keyHeld(bool up, bool left, bool down, bool right){
		if (left && !right) {
			tankBase.transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		}

		if (right && !left) {
			tankBase.transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		}

        if(up && !down) {
            tankController.accelerate();
        }

        if (down && !up) {
            tankController.decelerate();
        }

	}
}
