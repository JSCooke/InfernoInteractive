using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinPanelBehaviour : MonoBehaviour {

	// load scene according to button click
	public void LoadScene(int level)
	{
		SceneManager.LoadScene(level + 1);
	}

}
