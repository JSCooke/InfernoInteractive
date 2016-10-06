using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class customiseMenu : MonoBehaviour {

	public Canvas mainMenu;
    /*public GameObject[] AttackUpgrades = new GameObject[2];
    public GameObject[] DefenseUpgrades = new GameObject[1];
    public GameObject[] MovementUpgrades = new GameObject[0];
    public GameObject[] LeftUpgrades = new GameObject[2];
    public GameObject[] RightUpgrades = new GameObject[2];

    void Start()
    {
        for (int i = 0; i < AttackUpgrades.Length; i++)
        {
            AttackUpgrades[i].SetActive(false);
        }
        for (int i = 0; i < DefenseUpgrades.Length; i++)
        {
            DefenseUpgrades[i].SetActive(false);
        }
        for (int i = 0; i < MovementUpgrades.Length; i++)
        {
            MovementUpgrades[i].SetActive(false);
        }
        for (int i = 0; i < LeftUpgrades.Length; i++)
        {
            LeftUpgrades[i].SetActive(false);
        }
        for (int i = 0; i < RightUpgrades.Length; i++)
        {
            RightUpgrades[i].SetActive(false);
        }
    }*/

	public Camera tankCamera;

    public void BackPress()
    {
		this.GetComponent<Canvas> ().enabled = false;
		mainMenu.enabled = true;
    }

	void Update(){
		tankCamera.enabled = GetComponent<Canvas> ().enabled;
	}
			

    /*public void AttackUpgradeShow(GameObject upgradeObject)
    {
        for (int i = 0; i < AttackUpgrades.Length; i++)
        {
            AttackUpgrades[i].SetActive(false);
        }
        upgradeObject.SetActive(true);
    }

    public void DefenseUpgradeShow(GameObject upgradeObject)
    {
        for (int i = 0; i < DefenseUpgrades.Length; i++)
        {
            DefenseUpgrades[i].SetActive(false);
        }
        upgradeObject.SetActive(true);
    }

    public void MovementUpgradeShow(GameObject upgradeObject)
    {
        for (int i = 0; i < MovementUpgrades.Length; i++)
        {
            MovementUpgrades[i].SetActive(false);
        }
        upgradeObject.SetActive(true);
    }

    public void LeftUpgradeShow(GameObject upgradeObject)
    {
        for (int i = 0; i < LeftUpgrades.Length; i++)
        {
            LeftUpgrades[i].SetActive(false);
        }
        upgradeObject.SetActive(true);
    }

    public void RightUpgradeShow(GameObject upgradeObject)
    {
        for (int i = 0; i < RightUpgrades.Length; i++)
        {
            RightUpgrades[i].SetActive(false);
        }
        upgradeObject.SetActive(true);
    }*/
}
