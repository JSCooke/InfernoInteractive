using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class pauseMenuBehaviour : MonoBehaviour {

    public Canvas pauseMenu;
    public Button objective;
    public Button resume;
    public Button restart;
    public Button control;
    public Button mainMenu;


    // Use this for initialization
    void Start () {
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        objective = objective.GetComponent<Button>();
        resume = resume.GetComponent<Button>();
        restart = restart.GetComponent<Button>();
        control = control.GetComponent<Button>();
        mainMenu = mainMenu.GetComponent<Button>();
        pauseMenu.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {

            //TODO pause and unpause game and time

            pauseMenu.enabled = !pauseMenu.enabled; 
        }
    }

    public void ObjectivePress()
    {
        //TODO pass in string to the text object
        Application.LoadLevel("PauseMenuObjective");
    }

    public void ControlPress()
    {
        Application.LoadLevel("PauseMenuControls");
    }

    public void mainPress()
    {
        //TODO close the current game
        Application.LoadLevel("Main");
    }

    public void resumePress()
    {
        
    }

    public void restartPress()
    {
       
    }
}
