using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playMenu : MonoBehaviour {

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void BackPress()
    {
        SceneManager.LoadScene("Main");
    }
}
