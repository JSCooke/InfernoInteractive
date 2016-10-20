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
        //transform.position = Vector3.MoveTowards(transform.position, target.position, meteorSpeed * Time.deltaTime);

        //if (transform.position == target.position) {
        //    Destroy(this.transform.parent.gameObject);
        //    GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;
        //}
    }

    //Might cause null pointer
    void OnTriggerEnter(Collider collider) {

        Destroy(this.transform.parent.gameObject);
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;
        
    }

    void OnCollisionEnter(Collision collision) {

        Destroy(this.transform.parent.gameObject);
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;

    }
}
