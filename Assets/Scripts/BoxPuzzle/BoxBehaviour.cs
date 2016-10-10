using UnityEngine;
using System.Collections;

public class BoxBehaviour : MonoBehaviour

{
	private bool isMoving = false;

	// Use this for initialization
	void Start()
	{
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY 
			| RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;

	}
}
