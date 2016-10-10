using UnityEngine;
using System.Collections;

public class MazeUnitBehaviour : MonoBehaviour {

	public bool box;
	public bool hole;

	// Use this for initialization
	void Start () {
		if (box) { createBox(); }
		if (hole) { createHole(); }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createBox()
	{
		GameObject box = (GameObject)Instantiate(Resources.Load("Box"));
		box.transform.parent = transform;
		box.transform.localPosition = new Vector3(0f,3.5f,0f);
	}

	private void createHole()
	{
		transform.Find("Floor").gameObject.SetActive(false);
		GameObject hole = (GameObject)Instantiate(Resources.Load("Hole"));
		hole.transform.parent = transform;
		hole.transform.localPosition = new Vector3(0f, 0f, 0f);
	}
}
