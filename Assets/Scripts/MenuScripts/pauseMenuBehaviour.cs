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
		this.GetComponent<Canvas> ().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
			if (this.GetComponent<Canvas> ().isActiveAndEnabled) {
				//UNPAUSE
				this.GetComponent<Canvas> ().enabled = false;
			} else {
				//PAUSE
				if (controls.isActiveAndEnabled || objectives.isActiveAndEnabled) {
					objectives.enabled = false;
					controls.enabled = false;
					this.GetComponent<Canvas> ().enabled = true;
				} else {
					this.GetComponent<Canvas> ().enabled = true;
				}

			}

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
