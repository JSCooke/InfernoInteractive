using UnityEngine;
using System.Collections;

public class ElectricBoxController : MonoBehaviour {
    public GameObject explosion;
    public int explosionDelay;

    private int hitTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (hitTime != 0 && Time.frameCount > hitTime + explosionDelay) {
            Instantiate(explosion, transform.position, Quaternion.Euler(0,0,0));
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            if (hitTime == 0) {
                hitTime = Time.frameCount;
            }
        }
    }
}
