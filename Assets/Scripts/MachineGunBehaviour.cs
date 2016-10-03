using UnityEngine;
using System.Collections;

public class MachineGunBehaviour : ControlStationBehaviour {
	public GameObject gun, projectile, spawner;
	public float cooldown, maxAngle, rotationSpeed;

	private float lastShotTime;
	public override void keyHeld(bool up, bool left, bool down, bool right){
		if (left && !right) {

			gun.transform.Rotate (Vector3.up, -rotationSpeed * Time.deltaTime);

			if (gun.transform.localRotation.eulerAngles.y > maxAngle && gun.transform.localRotation.eulerAngles.y < 360 - maxAngle) {
				gun.transform.localRotation = Quaternion.Euler (0, 360 - maxAngle, 0);
			}

		}
		if (right && !left) {

			gun.transform.Rotate (Vector3.up, rotationSpeed * Time.deltaTime);

			if (gun.transform.localRotation.eulerAngles.y > maxAngle && gun.transform.localRotation.eulerAngles.y < 360 - maxAngle) {
				gun.transform.localRotation = Quaternion.Euler (0, maxAngle, 0);
			}
		}

		print (gun.transform.localRotation.eulerAngles.y);

		if (up && Time.fixedTime > lastShotTime + cooldown) {
			lastShotTime = Time.fixedTime;
			print (spawner.transform.rotation.eulerAngles);
			Instantiate (projectile, spawner.transform.position, spawner.transform.rotation);
		}
	}
}
