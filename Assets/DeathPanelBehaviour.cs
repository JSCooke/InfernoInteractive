using UnityEngine;
using System.Collections;

public class DeathPanelBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MenuTextPress()
	{
		//TODO close the current game
		Application.LoadLevel(0);
	}

	public void RetryTextPress()
	{
		//TODO close the current game
		Application.LoadLevel(1);
	}
}
