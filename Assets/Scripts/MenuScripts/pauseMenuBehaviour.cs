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
        foreach(Transform t in transform) {
            t.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
			if (this.GetComponent<Canvas> ().isActiveAndEnabled) {
                Unpause();
			} else {
                Pause();
			}
        }
    }

    public void Pause() {
        if (controls.isActiveAndEnabled || objectives.isActiveAndEnabled) {
            objectives.enabled = false;
            controls.enabled = false;
            this.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        } else {
            this.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        //enable all pause menu buttons
        foreach (Transform t in transform) {
            t.gameObject.SetActive(true);
        }
    }

    public void Unpause() {
        this.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;

        //disable all pause menu buttons
        foreach (Transform t in transform) {
            t.gameObject.SetActive(false);
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
		SceneManager.LoadScene("Main");
    }

    public void resumePress()
    {
        Unpause();
    }

    public void restartPress()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
