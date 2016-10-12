using UnityEngine;
using System.Collections;

public class WeakSpot : MonoBehaviour {

    public float baseRotationSpeed;
    private float rotationSpeed = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Rotation speed depends on difficulty. 50 for easy, 100 for medium, 150 for hard
        //if (rotationSpeed != (GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty -1) * baseRotationSpeed) {
        //    rotationSpeed = (GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossController>().difficulty - 1) * baseRotationSpeed;
        //}

        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }
}
