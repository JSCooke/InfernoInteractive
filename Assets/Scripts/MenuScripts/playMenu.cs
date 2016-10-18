using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playMenu : MonoBehaviour {
	
    public Image Preview;
    public Text Desciption;
	public Canvas mainMenu;

	//Arrays of sprites and descriptions cooresponding to levels
    public Sprite[] levelSprites = new Sprite[5];
    string[] descriptions = new string[5];

    void Start()
    {
        SetDescriptions();
    }

    public void LoadScene(int level)
    {
		//Each level button calls this function to load the appropriate scene for that level
		print (level);
        SceneManager.LoadScene(level+1);
    }

    public void BackPress()
    {
		//Shows main menu
		this.GetComponent<Canvas> ().enabled = false;
		mainMenu.enabled = true;
    }

    public void ShowPreview(int level)
    {
		//Shows preview of sprite and description of level on hover
        Preview.sprite = levelSprites[level - 1];
        Desciption.text = descriptions[level - 1];
    }

    void SetDescriptions()
    {
		//List of level descriptions
        descriptions[0] = "Defeat Slime Boss";
        descriptions[1] = "Navigate the Maze";
        descriptions[2] = "Chase away the Invaders";
        descriptions[3] = "[To Remove]";
        descriptions[4] = "[To Remove]";
    }
}
