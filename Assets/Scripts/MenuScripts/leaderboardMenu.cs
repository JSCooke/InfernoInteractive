using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class leaderboardMenu : MonoBehaviour {

	//Array of leaderboard canvas for each level
    public Canvas[] Leaderboards = new Canvas[5];
    Canvas Menu;
	public Canvas mainMenu;

    void Start()
    {
		//Hide leaderboards and show level select
        for (int i = 0; i < Leaderboards.Length; i++)
        {
            Leaderboards[i].enabled = false;
        }
        Menu = this.GetComponent<Canvas>();
        Menu.enabled = false;
    }

    public void BackPress()
    {
		//Show main menu
		this.GetComponent<Canvas> ().enabled = false;
		mainMenu.enabled = true;
    }

    public void LevelPress(int level)
    {
		//Show leaderboard and hide level select
        Leaderboards[level - 1].enabled = true;
        Menu.enabled = false;
    }

    public void ExitLeaderBoard()
    {
		//Hide leaderboards and show level select
        for (int i = 0; i < Leaderboards.Length; i++)
        {
            Leaderboards[i].enabled = false;
        }
        Menu.enabled = true;
    }
}
