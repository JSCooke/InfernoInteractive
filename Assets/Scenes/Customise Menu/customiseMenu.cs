using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class customiseMenu : MonoBehaviour {

    public void BackPress()
    {
        SceneManager.LoadScene("Main");
    }
}
