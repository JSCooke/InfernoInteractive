using UnityEngine;
using System.Collections;

public class BigCannonBehaviour : ControlStationBehaviour {
    public UnityEngine.GameObject projectile, projectileSpawn;
    public int cooldown;

    private int lastShotTime;
    public override void keyPressed(bool up, bool left, bool down, bool right) {
        if (up && Time.frameCount - lastShotTime > cooldown) {
            lastShotTime = Time.frameCount;
            Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        }

    }
}
