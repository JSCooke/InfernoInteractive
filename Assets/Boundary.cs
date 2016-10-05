using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

    public string projectile;

    void OnTriggerExit(Collider other) {
        print(other.gameObject.tag);
        if (other.gameObject.tag == projectile) {
            Destroy(other.gameObject);
        }   
    }
}
