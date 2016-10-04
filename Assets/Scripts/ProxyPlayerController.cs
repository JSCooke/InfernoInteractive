using UnityEngine;
using System.Collections;

public class ProxyPlayerController : MonoBehaviour {
	public UnityEngine.GameObject original;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = original.transform.localPosition;
	}
}
