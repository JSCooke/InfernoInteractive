using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathPanelBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MenuTextPress()
	{
        //TODO close the current game
        SceneManager.LoadScene("Main");
	}

	public void RetryTextPress()
	{
        //TODO close the current game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
