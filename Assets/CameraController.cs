using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject target;
	public float height;
	public float dampTime;

	private Vector3 velocity = Vector3.zero;
	private Camera camera;
	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () { 
		Vector3 point = camera.WorldToViewportPoint(target.transform.position);
		Vector3 delta = target.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, height)); //(new Vector3(0.5, 0.5, point.z));
		Vector3 destination = transform.position + delta;
		transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

		//transform.position = target.transform.position + offset;
	}
}
