using UnityEngine;
using System.Collections;

public class BossDialog : ActivateNewDialog {
    public Animator bossAnimator;
    public TankController tank;
    public int spawnLine;
    public bool done = false;
	// Use this for initialization
	void Start () {
        bossAnimator.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (dialogManager.currentLineNumber == spawnLine) {
            bossAnimator.gameObject.SetActive(true);
        }
        if(dialogManager.currentLineNumber == dialogManager.endLineNumber + 1) {
            bossAnimator.SetBool("Ready", true);
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
        base.OnTriggerEnter(other);
        //Stop the tank and disable players
        tank.GetComponent<Rigidbody>().velocity = Vector3.zero;
        tank.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        foreach (PlayerController player in Object.FindObjectsOfType<PlayerController>()) {
            player.enabled = false;
        }
    }
}
