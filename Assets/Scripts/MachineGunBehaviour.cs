using UnityEngine;
using System.Collections.Generic;

public class MachineGunBehaviour : ControlStationBehaviour {
	public GameObject gun, projectile;
	public float cooldown, maxAngle, rotationSpeed;

	private float lastShotTime;
    private List<GameObject> spawners;
    private GameObject tank;
    void Start() {
        spawners = new List<GameObject>();
        foreach (Transform transform in gun.transform) {
            if(transform.gameObject.name=="Projectile Spawner") {
                spawners.Add(transform.gameObject);
            }
        }
        tank = GetComponentInParent<TankController>().gameObject;
    }

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

		//print (gun.transform.localRotation.eulerAngles.y);

		if (up && Time.fixedTime > lastShotTime + cooldown) {

            //fail the cannon only achievement
			AchievementController.hasUsedOnlyCannon = false;

            foreach (GameObject spawner in spawners)
            {
                lastShotTime = Time.fixedTime;

                //Instantiate the shot
                GameObject shot = (GameObject)Instantiate(projectile, spawner.transform.position, spawner.transform.rotation);

                //Set its inherent velocity to be the velocity of the tank as it shot the projectile
                Vector3 inherentVelocity = tank.GetComponent<Rigidbody>().velocity;
                shot.GetComponent<ProjectileController>().inherentVelocity = inherentVelocity;
            }
		}
	}
}
