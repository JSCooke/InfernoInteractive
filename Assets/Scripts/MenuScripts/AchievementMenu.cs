using UnityEngine;
using System.Collections;

public class AchievementMenu : MonoBehaviour {

	public Canvas mainMenu;

	public void BackPress()
	{
		this.GetComponent<Canvas> ().enabled = false;
		mainMenu.enabled = true;
	}
}
