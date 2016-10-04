using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class controlMenuBehaviour : MonoBehaviour {

	public Canvas pauseMenu;

	public void pressReturn()
	{
		this.GetComponent<Canvas> ().enabled = false;
		pauseMenu.enabled = true;
	}
}
