using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
    public float speed;
	public int damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
