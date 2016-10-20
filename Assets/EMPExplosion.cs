using UnityEngine;
using System.Collections;

public class EMPExplosion : MonoBehaviour {
    public GameObject endTriggerZone;
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<ParticleSystem>().IsAlive()) {
            endTriggerZone.SetActive(true);
            Destroy(gameObject);
        }
	}
}
