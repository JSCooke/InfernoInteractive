using UnityEngine;
using System.Collections;

public class EMPExplosion : MonoBehaviour {
    public GameObject endTriggerZone;
    public BossDoorController exitDoor;
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<ParticleSystem>().IsAlive()) {
            endTriggerZone.SetActive(true);
            Destroy(gameObject);
            //Open the exit door
            exitDoor.open = true;
        }
	}
}
