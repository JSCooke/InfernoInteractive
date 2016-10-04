using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class pauseMenuBehaviour : MonoBehaviour {

	public Canvas objectives;
	public Canvas controls;


    // Use this for initialization
    void Start () {

		objectives.enabled = false;
		controls.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {

			//UNPAUSE
			this.GetComponent<Canvas> ().enabled = false;
        }
    }

    public void ObjectivePress()
    {
		objectives.enabled = true;
		this.GetComponent<Canvas> ().enabled = false;
    }

    public void ControlPress()
    {
		controls.enabled = true;
		this.GetComponent<Canvas> ().enabled = false;
    }

    public void mainPress()
    {
        //TODO close the current game
        Application.LoadLevel(0);
    }

    public void resumePress()
    {
		//UNPAUSE
		this.GetComponent<Canvas> ().enabled = false;
    }

    public void restartPress()
    {
		Application.LoadLevel(1);
    }
}
