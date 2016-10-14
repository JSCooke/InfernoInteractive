using UnityEngine;
using System.Collections;

public class MapBehaviour : MonoBehaviour {

	public float rotateSpeed = 1;
	public float translateSpeed = 1;
	public float translateAmplitude = 1;

	private Vector3 _startPosition;

	// Use this for initialization
	void Start () {
		_startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 20 * Time.deltaTime * rotateSpeed);

		transform.position = _startPosition + new Vector3(0.0f, translateAmplitude * Mathf.Sin(Time.time * translateSpeed), 0.0f);
	}
}
