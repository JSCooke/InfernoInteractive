using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class customiseMenu : MonoBehaviour {

	public Canvas mainMenu;

	public Camera tankCamera;

    public void BackPress()
    {
		//Show main menu
		this.GetComponent<Canvas> ().enabled = false;
		mainMenu.enabled = true;
    }

	void Update(){
		//Use tank camera only if customise menu is shown
		tankCamera.enabled = GetComponent<Canvas> ().enabled;
	}
}
