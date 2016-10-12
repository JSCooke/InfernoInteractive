using UnityEngine;
using System.Collections;

public class ShieldGenerator : MonoBehaviour {

    public static float lastHitTime;
    public static int hitCount = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //Must hit BOTH generators simultaneously (within 0.5s) to deactivate shield
        if ((Time.fixedTime - lastHitTime) > 0.5) {
            hitCount = Mathf.Clamp(hitCount - 1, 0, 2);
        }
    }

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "PlayerProjectile") {
            lastHitTime = Time.fixedTime;
            hitCount++;
            Destroy(collision.gameObject);
        }

    }
}
