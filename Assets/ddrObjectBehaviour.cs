using UnityEngine;
using System.Collections;

public class ddrObjectBehaviour : Damageable
{

    public float speed;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
