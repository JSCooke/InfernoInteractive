using UnityEngine;
using System.Collections;

public class BossDialog : ActivateNewDialog {
    public Animator bossAnimator;
    public TankController tank;
    public int spawnLine;
    public bool done = false;
    public bool activated = false;
	// Use this for initialization
	public override void Start () {
        base.Start();
        bossAnimator.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (!activated) {
            return;
        }
        if (dialogManager.currentLineNumber == spawnLine) {
            bossAnimator.gameObject.SetActive(true);
        }
        if(dialogManager.currentLineNumber == dialogManager.endLineNumber + 1) {
            bossAnimator.SetBool("Ready", true);
			SoundAdapter.altTrack ();
            done = true;
            Destroy(gameObject);
        }
        if (done) {
            foreach (PlayerController player in Object.FindObjectsOfType<PlayerController>()) {
                player.enabled = true;
            }

        }
	}

    public override void OnTriggerEnter(Collider other) {
        if (done || other.name != "Tank") {
            return;
        }
        activated = true;
        base.OnTriggerEnter(other);
        //Stop the tank and disable players
        tank.GetComponent<Rigidbody>().velocity = Vector3.zero;
        tank.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        tank.gameObject.GetComponentInChildren<Wheel_Control_CS>().speed = 0;
        tank.gameObject.GetComponentInChildren<Wheel_Control_CS>().rotation = 0;

        foreach (PlayerController player in Object.FindObjectsOfType<PlayerController>()) {
            player.enabled = false;
        }

        UIAdapter.setBossUI(true);

        //Zoom out the camera
        mainCamera.GetComponent<Camera>().fieldOfView = 90;
    }
}
