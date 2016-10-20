﻿using UnityEngine;
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

        //load all of the achievements
        AchievementController.load();


		foreach (KeyValuePair<string, bool> entry in AchievementController.achievements) {
			foreach (Transform t in GetComponentsInChildren<Transform>()) {
				print(t.gameObject.name +", " + entry.Key);
				if (t.gameObject.name == entry.Key) {


					//if the achievement is earned set the alpha of the image to max
					if (entry.Value == true) {
                        foreach (Transform c in t) {
                            print(c.gameObject.name);
                            //setting the icons alpha
                            if (c.gameObject.name == "achieveImage") {
                                Image temp3 = c.gameObject.GetComponent<Image>();
                                Color temp4 = temp3.color;
                                temp4.a = 0.95f;
                                temp3.color = temp4;
                            }
							if (c.gameObject.name == "achieveDescription") {
								Text text1 = c.gameObject.GetComponent<Text>();
								text1.text=text1.text.Substring (11);
							}
                        }
                       
                        //setting the panels alpha
                        Image temp2 = t.gameObject.GetComponent<Image>();
						Color temp = temp2.color;
						temp.a = 1f;
                        temp.r = 0.4f;
                        temp.g = 1f;
                        temp.b = 0.45f;
                        temp2.color = temp;

					}

					//yay you found it
					print(t.gameObject.name);
				}
			}


		}

	}
}
