using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class objectiveMenuBehaviour : MonoBehaviour {
    public Canvas objectiveMenu;
    public Button returnBtn;
    public Text objectiveDescription;

    // Use this for initialization
    void Start () {
        objectiveMenu = objectiveMenu.GetComponent<Canvas>();
        returnBtn = returnBtn.GetComponent<Button>();
        objectiveDescription = objectiveDescription.GetComponent<Text>();
        objectiveMenu.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void pressReturn()
    {
        Application.LoadLevel("PauseMenu");
    }
}
