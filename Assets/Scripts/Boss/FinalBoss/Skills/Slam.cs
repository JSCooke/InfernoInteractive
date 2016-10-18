using UnityEngine;
using System.Collections;

public class Slam : MonoBehaviour {

    public string playerName = "Tank";
    public float speed = 1f;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find(playerName).transform.position, speed);
    }

}
