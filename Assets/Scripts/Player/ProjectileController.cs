using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
    public float speed;
	public int damage;
	public GameObject endAnimation;
    public Vector3 inherentVelocity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position+=transform.forward * speed * Time.deltaTime;
        if(Vector3.AngleBetween(transform.forward, inherentVelocity)<90) {
            transform.position += inherentVelocity * Time.deltaTime;
        }
    }

	void OnDestroy(){
		Instantiate (endAnimation, transform.position, transform.rotation);
	}

}
