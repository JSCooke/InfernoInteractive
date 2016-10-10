using UnityEngine;
using System.Collections;

public class MazeUnitBehaviour : MonoBehaviour {

	public bool box;
	public bool hole;

	// Use this for initialization
	void Start () {
		if (box) { createBox(); }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createBox()
	{
		GameObject box = (GameObject)Instantiate(Resources.Load("Box"));
		box.transform.parent = transform;
		//print();
		box.transform.localPosition = new Vector3(0f,3.5f,0f);
		//UnityEngine.GameObject newStation = (UnityEngine.GameObject)Instantiate(station, transform.position, transform.rotation);
		//newStation.transform.parent = transform;
	}
}
