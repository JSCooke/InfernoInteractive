using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class customiseMenu : MonoBehaviour {

    public GameObject[] upgradeObjects = new GameObject[7];

    void Start()
    {

    }

    public void BackPress()
    {
        SceneManager.LoadScene("Main");
    }

    public void UpgradeShow(GameObject upgradeObject)
    {

    }
}
