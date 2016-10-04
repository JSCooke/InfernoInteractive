using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class controlMenuBehaviour : MonoBehaviour {

    public Canvas controlMenu;
    public Button returnBtn;

    // Use this for initialization
    void Start()
    {
        controlMenu = controlMenu.GetComponent<Canvas>();
        returnBtn = returnBtn.GetComponent<Button>();
        controlMenu.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pressReturn()
    {
        Application.LoadLevel("PauseMenu");
    }
}
