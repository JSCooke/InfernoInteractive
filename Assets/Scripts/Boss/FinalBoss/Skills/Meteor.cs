using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    public Transform target;
    public float meteorSpeed = 12f;
    public int forcePush = 10;

    // Use this for initialization
    void Start() {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 playerDirection = target.transform.position - this.transform.position;
        playerDirection = playerDirection.normalized;
        rb.AddForce(playerDirection * forcePush);
    }

    // Update is called once per frame
    void Update() {

    }


    void OnTriggerEnter(Collider collider) {
		SoundAdapter.playFenceSound ();
		SoundAdapter.playBombSound ();
		Destroy(this.transform.parent.gameObject);
		GameObject.Find("FinalBoss").GetComponent<FinalBossBehaviour>().newAction = true;
        
    }

    void OnCollisionEnter(Collision collision) {
		SoundAdapter.playFenceSound ();
		SoundAdapter.playBombSound ();
        Destroy(this.transform.parent.gameObject);
		GameObject.Find("FinalBoss").GetComponent<FinalBossBehaviour>().newAction = true;

    }
}
