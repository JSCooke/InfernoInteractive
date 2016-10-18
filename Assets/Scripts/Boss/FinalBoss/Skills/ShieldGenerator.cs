using UnityEngine;
using System.Collections;

public class ShieldGenerator : MonoBehaviour {

    public string damagedBy;
    public GameObject shield;
    public float lastHitTime;
    public int side;    //0 is left and 1 is right

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //Must hit BOTH generators simultaneously (within 0.5s) to deactivate shield
        if (!shield.GetComponent<Shield>().generatorDestroyed() && (Time.fixedTime - lastHitTime) > 0.5) {
            shield.GetComponent<Shield>().hitCount[side] = false;
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == damagedBy) {
            lastHitTime = Time.fixedTime;
            shield.GetComponent<Shield>().hitCount[side] = true;
            Destroy(collider.gameObject);
        }
    }
}
