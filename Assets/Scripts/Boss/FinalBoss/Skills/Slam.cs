using UnityEngine;
using System.Collections;

public class Slam : MonoBehaviour {

    public string playerName = "Tank";
    public float speed = 1f;
    private ParticleSystem shockwave;

	// Use this for initialization
	void Start () {

        ParticleSystem lol = this.GetComponentsInChildren<ParticleSystem>()[0];
        
        lol.startRotation = Mathf.Deg2Rad * 90;
    }

    // Update is called once per frame
    void Update() {
        Vector3 relativePos = GameObject.Find(playerName).transform.position - this.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        ParticleSystem lol = this.GetComponentsInChildren<ParticleSystem>()[0];
        lol.startRotation = Mathf.Deg2Rad * rotation.eulerAngles.y;
        lol.startLifetime = 1;
        lol.startSize = 30;
        lol.Play();
        //transform.position = Vector3.MoveTowards(transform.position, GameObject.Find(playerName).transform.position, speed);
    }

}
