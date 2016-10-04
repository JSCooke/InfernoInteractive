using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playMenu : MonoBehaviour {

    public Image Preview;
    public Text Desciption;
	public Canvas mainMenu;

    public Sprite[] levelSprites = new Sprite[5];
    string[] descriptions = new string[5];

    void Start()
    {
        SetDescriptions();
    }

    public void LoadScene(int level)
    {
		print (level);
        SceneManager.LoadScene(level);
    }

    public void BackPress()
    {
		this.GetComponent<Canvas> ().enabled = false;
		mainMenu.enabled = true;
    }

    public void ShowPreview(int level)
    {
        Preview.sprite = levelSprites[level - 1];
        Desciption.text = descriptions[level - 1];
    }

    void SetDescriptions()
    {
        descriptions[0] = "Defeat Slime Boss";
        descriptions[1] = "Pirate Level";
        descriptions[2] = "Navigate the Maze";
        descriptions[3] = "Separated";
        descriptions[4] = "Final Chase";
    }
}
