using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class objectiveMenuBehaviour : MonoBehaviour {
	
    public Text objectiveDescription;
	public Canvas pauseMenu;

    // Use this for initialization
    void Start () {

        objectiveDescription = objectiveDescription.GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void pressReturn()
    {
		this.GetComponent<Canvas> ().enabled = false;
		pauseMenu.enabled = true;
    }
}
