using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AchievementMenu : MonoBehaviour {

	public Canvas mainMenu;

	void Start(){
		updateAchievements ();
	}

	public void BackPress()
	{
		this.GetComponent<Canvas> ().enabled = false;
		mainMenu.enabled = true;
	}


	//called to update all current achievements
	public void updateAchievements(){
		foreach (KeyValuePair<string, bool> entry in AchievementController.achievements) {
			foreach (Transform t in GetComponentsInChildren<Transform>()) {
				print(t.gameObject.name +", " + entry.Key);
				if (t.gameObject.name == entry.Key) {


					//if the achievement is earned set the alpha of the image to max
					if (entry.Value == true) {
						Image temp2 = t.gameObject.GetComponent<Image>();
						Color temp = temp2.color;
						temp.a = 1f;
						temp2.color = temp;
					}

					//yay you found it
					print(t.gameObject.name);
				}
			}


		}
	}
}
