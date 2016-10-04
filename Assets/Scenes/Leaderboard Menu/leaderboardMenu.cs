using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class leaderboardMenu : MonoBehaviour {

    public Canvas[] Leaderboards = new Canvas[5];
    Canvas Menu;

    void Start()
    {
        for (int i = 0; i < Leaderboards.Length; i++)
        {
            Leaderboards[i].enabled = false;
        }
        Menu = this.GetComponent<Canvas>();
        Menu.enabled = true;
    }

    public void BackPress()
    {
        SceneManager.LoadScene("Main");
    }

    public void LevelPress(int level)
    {
        Leaderboards[level - 1].enabled = true;
        Menu.enabled = false;
    }

    public void ExitLeaderBoard()
    {
        for (int i = 0; i < Leaderboards.Length; i++)
        {
            Leaderboards[i].enabled = false;
        }
        Menu.enabled = true;
    }
}
