using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Destroy(this.gameObject);
        }
       
    }
}
