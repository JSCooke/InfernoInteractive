using UnityEngine;
using System.Collections;

public class BigCannonBehaviour : ControlStationBehaviour {
    public UnityEngine.GameObject projectile, projectileSpawn;
    public int cooldown;

    private GameObject tank;
    private int lastShotTime;

    void Start() {
        tank = GetComponentInParent<TankController>().gameObject;
    }

    public override void keyPressed(bool up, bool left, bool down, bool right) {
        if (up && Time.frameCount - lastShotTime > cooldown) {
            lastShotTime = Time.frameCount;

            //Instantiate the shot
            GameObject shot = (GameObject)Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);

            //Set its inherent velocity to be the velocity of the tank as it shot the projectile
            Vector3 inherentVelocity = tank.GetComponent<Rigidbody>().velocity;
            shot.GetComponent<ProjectileController>().inherentVelocity = inherentVelocity;
        }

    }
}
