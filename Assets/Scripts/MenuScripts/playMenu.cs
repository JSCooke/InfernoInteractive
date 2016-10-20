using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playMenu : MonoBehaviour {
	
    public Image Preview;
    public Text Desciption;
	public Canvas mainMenu;

    //Arrays of sprites and descriptions cooresponding to levels
    public Sprite[] levelSprites;
    public string[] descriptions;
    public GameObject[] levelButtons;

    void Start()
    {   
        //Check how many levels are unlocked
        if(GameData.get<int>("levels unlocked") == default(int)) {
            GameData.put("levels unlocked", 1);
        }
        for(int i = 0; i < levelButtons.Length; i++) {
            levelButtons[i].SetActive(false);
        }
        for (int i = 0; i < GameData.get<int>("levels unlocked"); i++) {
            levelButtons[i].SetActive(true);
        }

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
}
