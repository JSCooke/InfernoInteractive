using UnityEngine;
using System.Collections;

public class BigCannonBehaviour : ControlStationBehaviour {
    public UnityEngine.GameObject projectile, projectileSpawn, cabin, tank;
	public TankController tankController;
    public int cooldown;
	public float rotationSpeed;

    private bool isClone;

	void Start(){
		//Auto-find tank references on start
		tankController = GetComponentInParent<TankController> ();
		tank = tankController.gameObject;
		cabin = tank.transform.Find ("Cabin").gameObject;
        isClone = GetComponentInParent<TankCloner>().isClone;
	}

	private int lastShotTime;
    public override void keyPressed(bool up, bool left, bool down, bool right) {
        if (up && Time.frameCount - lastShotTime > cooldown && !isClone) {
            lastShotTime = Time.frameCount;
			SoundAdapter.playCannonMk1Sound ();
            Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        }
    }

	//uncomment below if you want the cabin to move

	public override void keyHeld(bool up, bool left, bool down, bool right){
		if (left && !right) {
			cabin.transform.Rotate (0, -50 * Time.deltaTime, 0);
		}
	
		if (right && !left) {
			cabin.transform.Rotate (0, 50 * Time.deltaTime, 0);
		}
	}

}
