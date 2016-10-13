using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    public Transform target;
    public float meteorSpeed = 5f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() { 
        transform.position = Vector3.MoveTowards(transform.position, target.position, meteorSpeed * Time.deltaTime);

        if (transform.position == target.position) {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
