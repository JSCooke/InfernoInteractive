using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class SettingBehaviour : MonoBehaviour {
    public Canvas setting;
    public Button returnBtn;

    // Use this for initialization
    void Start()
    {
        setting = setting.GetComponent<Canvas>();
        returnBtn = returnBtn.GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Use this when "Play" button is pressed
    public void returnPress()
    {
        SceneManager.LoadScene("Main");
    }
}
