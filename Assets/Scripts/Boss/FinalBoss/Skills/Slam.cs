using UnityEngine;
using System.Collections;

public class Slam : MonoBehaviour {

    public string playerName = "Tank";
    public float speed;
    public float damage = 10;
    public Vector3 target;

	// Use this for initialization
	void Start () {

        Vector3 dir = target - transform.position;
        dir = dir.normalized;
        GetComponent<Rigidbody>().AddForce(dir * 1000 * speed);

    }

    // Update is called once per frame
    void Update() {
        //transform.position = Vector3.MoveTowards(transform.position, target, speed);

        //if (transform.position == target) {
        //    Destroy(this.gameObject);
        //    GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;
        //}
    }

    void OnTriggerEnter(Collider collider) {

        if (collider.gameObject.tag == "Player") {
            GameObject.Find(playerName).GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.Find(playerName).GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            collider.gameObject.GetComponent<TankController>().takeDamage(damage);
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            GameObject.Find(playerName).GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.Find(playerName).GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            other.gameObject.GetComponent<TankController>().takeDamage(damage);
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;
        }

        if (other.gameObject.tag == "Floor") {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;
        }
    }

}
