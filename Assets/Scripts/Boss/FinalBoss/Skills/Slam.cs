using UnityEngine;
using System.Collections;

public class Slam : MonoBehaviour {

    public string playerName = "Tank";
    public float speed;
    public float damage = 10;
    public Vector3 target;
    public float knockBack;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, target, speed);

        if (transform.position == target    ) {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;
        }
    }

    void OnTriggerEnter(Collider collider) {

        if (collider.gameObject.tag == "Player") {
            GameObject.Find(playerName).GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.Find(playerName).GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            Vector3 forceDir = GameObject.Find(playerName).transform.position - transform.position;
            GameObject.Find(playerName).GetComponent<Rigidbody>().AddForce(forceDir * knockBack * 1000);    //1000 is mass of tank

            collider.gameObject.GetComponent<TankController>().takeDamage(damage);
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;
        }
    }

}
