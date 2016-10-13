using UnityEngine;
using System.Collections;

public class MovementStationBehaviour : ControlStationBehaviour {
	public UnityEngine.GameObject tank;
    public TankController tankController;
	public UnityEngine.GameObject tankBase;
    public Wheel_Control_CS wheelController;

	void Start(){
		//Auto-find tank references on start
		tankController = GetComponentInParent<TankController> ();
		tank = tankController.gameObject;
		tankBase = tank.transform.Find ("Treads").gameObject;
        wheelController = tankBase.GetComponentInChildren<Wheel_Control_CS>();
	}

	public override void keyHeld(bool up, bool left, bool down, bool right){
        wheelController.speed = 0;
        wheelController.rotation = 0;

        if (up) {
            wheelController.speed += 1;
        }
        if (down) {
            wheelController.speed -= 1;
        }

        if (left) {
            wheelController.rotation -= 1;
		}
		if (right) {
            wheelController.rotation += 1;
		}
	}
}
