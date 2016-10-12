using UnityEngine;
using System.Collections;

public class WeakSpot : MonoBehaviour {

    public string damagedBy;
    public GameObject hollowWall;

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == damagedBy) {
            Destroy(collider.gameObject);
            hollowWall.GetComponent<HollowWall>().health -= collider.gameObject.GetComponent<ProjectileController>().damage;
        }
    }
}
