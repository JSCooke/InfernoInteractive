using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class AchievementBehaviour : MonoBehaviour {
    public Canvas achievement;
    public Button returnBtn;

    // Use this for initialization
    void Start ()
    {
        achievement = achievement.GetComponent<Canvas>();
        returnBtn = returnBtn.GetComponent<Button>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //Use this when "Play" button is pressed
    public void returnPress()
    {
        SceneManager.LoadScene("Main");
    }
}
