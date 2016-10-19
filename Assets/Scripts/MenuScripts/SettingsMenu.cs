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
	void Start() {
		GameObject.Find ("musicSlider").GetComponent<UnityEngine.UI.Slider> ().value = SoundAdapter.musicVolume;
		GameObject.Find ("soundSlider").GetComponent<UnityEngine.UI.Slider> ().value = SoundAdapter.soundVolume;
	}
}
