using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public UnityEngine.GameObject target;

	public bool smooth;
	public float height;
	public float dampTime;

	private Vector3 velocity = Vector3.zero;
	private Camera camera;
	public AudioSource bgm;
	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
		bgm = GetComponentInChildren<AudioSource> ();
		bgm.loop = true;
		bgm.Play();
	}
	
	// Update is called once per frame
	void Update () { 
		if (smooth) {
			//Smooth camera movement
			//Reference: http://answers.unity3d.com/questions/29183/2d-camera-smooth-follow.html
			Vector3 point = camera.WorldToViewportPoint (target.transform.position);
			Vector3 delta = target.transform.position - camera.ViewportToWorldPoint (new Vector3 (0.5f, 0.3f, height)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
		} else {
			transform.position = target.transform.position + new Vector3 (0, 30, 5);
            transform.rotation = Quaternion.Euler(85, 0, 0);
		}
	}
}
