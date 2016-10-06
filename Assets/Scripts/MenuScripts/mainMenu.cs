using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class mainMenu : MonoBehaviour {

    public Canvas quitMenu;
	public Button quitButton;

	public Canvas playMenu;
    public Button playButton;
    
	public Canvas leaderboardMenu;
	public Button leaderboardButton;
    
	public Canvas customiseMenu;
	public Button customiseButton;
    
	public Canvas achievementMenu;
	public Button achievementsButton;
    
	public Canvas settingsMenu;
	public Button settingsButton;
    

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


		//turn off all other canvas
		playMenu.enabled = false;
		leaderboardMenu.enabled = false;
		customiseMenu.enabled = false;
		achievementMenu.enabled = false;
		settingsMenu.enabled = false;

    }

    //Use this when "Play" button is pressed
    public void PlayPress()
    {
		playMenu.enabled = true;
		this.GetComponent<Canvas> ().enabled = false;
    }

    //Use this when "Leaderboard" is pressed
    public void LeaderboardPress()
    {
		leaderboardMenu.enabled = true;
		this.GetComponent<Canvas> ().enabled = false;
    }

    //Use this when "Customise" is pressed
    public void CustomisePress()
    {
		customiseMenu.enabled = true;
		this.GetComponent<Canvas> ().enabled = false;
    }

    //Use this when "Achievements" is pressed
    public void AchievementsPress()
    {
		achievementMenu.enabled = true;
		this.GetComponent<Canvas> ().enabled = false;
    }

    //Use this when "Settings" is pressed
    public void SettingsPress()
    {
		settingsMenu.enabled = true;
		this.GetComponent<Canvas> ().enabled = false;
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
