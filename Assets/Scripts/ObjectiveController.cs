using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectiveController : MonoBehaviour {

    public Text timerObjectiveText;
    public Text pauseMenuObjectiveText;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setNewObjective(string objective, string shortObjective)
    {
        timerObjectiveText.text = shortObjective;
        pauseMenuObjectiveText.text = objective;
    }

}
