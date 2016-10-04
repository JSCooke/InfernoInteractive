using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class mainMenu : MonoBehaviour {

    public Canvas quitMenu;
    public Button playButton;
    public Button leaderboardButton;
    public Button customiseButton;
    public Button achievementsButton;
    public Button settingsButton;
    public Button quitButton;

    // Use this for initialization
    void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
        leaderboardButton = leaderboardButton.GetComponent<Button>();
        customiseButton = customiseButton.GetComponent<Button>();
        achievementsButton = achievementsButton.GetComponent<Button>();
        settingsButton = settingsButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    //Use this when "Play" button is pressed
    public void PlayPress()
    {
        SceneManager.LoadScene("Play");
    }

    //Use this when "Leaderboard" is pressed
    public void LeaderboardPress()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    //Use this when "Customise" is pressed
    public void CustomisePress()
    {
        SceneManager.LoadScene("Customise");
    }

    //Use this when "Achievements" is pressed
    public void AchievementsPress()
    {
        SceneManager.LoadScene("MenuAchievements");
    }

    //Use this when "Settings" is pressed
    public void SettingsPress()
    {
        SceneManager.LoadScene("MenuSetting");
    }

    //Use this when "Exit" is pressed
    public void ExitPress()
    {
        quitMenu.enabled = true;
        playButton.enabled = false;
        leaderboardButton.enabled = false;
        customiseButton.enabled = false;
        achievementsButton.enabled = false;
        settingsButton.enabled = false;
        quitButton.enabled = false;
    }

    //Use this when "No" is pressed after "Exit"
    public void NoPress()
    {
        quitMenu.enabled = false;
        playButton.enabled = true;
        leaderboardButton.enabled = true;
        customiseButton.enabled = true;
        achievementsButton.enabled = true;
        settingsButton.enabled = true;
        quitButton.enabled = true;
    }

    //Use this when "Yes" is pressed after "Exit"
    public void ExitGame()
    {
        Application.Quit();
    }
}
