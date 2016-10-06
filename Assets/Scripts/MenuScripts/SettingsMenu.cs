using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {

	public Canvas mainMenu;

	public void BackPress()
	{
		this.GetComponent<Canvas> ().enabled = false;
		mainMenu.enabled = true;
	}
    public void setDifficulty(string difficulty) {
        if (difficulty == "easy") {
            GameData.put("difficulty",BossController.Difficulty.Easy);
        }
        if (difficulty == "medium") {
            GameData.put("difficulty", BossController.Difficulty.Medium);
        }
        if (difficulty == "hard") {
            GameData.put("difficulty", BossController.Difficulty.Hard);
        }
    }
}
