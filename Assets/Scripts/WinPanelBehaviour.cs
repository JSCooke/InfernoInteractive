using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinPanelBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MenuTextPress()
	{
        //TODO close the current game
        SceneManager.LoadScene("Main");
	}

}
