using UnityEngine;
using System.Collections;

public class Slam : MonoBehaviour {

    public string playerName = "Tank";
    public float speed = 1f;
    public float damage = 10;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find(playerName).transform.position, speed);
    }

    void OnTriggerEnter(Collider collider) {

        if (collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<TankController>().takeDamage(damage);
            //print(damage);
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FinalBossBehaviour>().newAction = true;
        }
    }

}
