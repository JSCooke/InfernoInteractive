using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class upgradeSelect : MonoBehaviour {

	//All control station canvases
    public GameObject AttackStation;
    public GameObject DefenseStation;
    public GameObject MovementStation;
    public GameObject LeftStation;
    public GameObject RightStation;

    void Start()
    {
		//Show Northern station upgrades on start
        AttackStation.SetActive(true);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        LeftStation.SetActive(false);
        RightStation.SetActive(false);
    }

    public void DisplayAttackUpgrades()
    {
		//Display Northern station upgrades
        AttackStation.SetActive(true);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        LeftStation.SetActive(false);
        RightStation.SetActive(false);
    }

    public void DisplayDefenseUpgrades()
    {
		//Display Southern station upgrades
		AttackStation.SetActive(false);
        DefenseStation.SetActive(true);
        MovementStation.SetActive(false);
        LeftStation.SetActive(false);
        RightStation.SetActive(false);
    }

    public void DisplayMovementUpgrades()
    {
		//Display Central station upgrades
		AttackStation.SetActive(false);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(true);
        LeftStation.SetActive(false);
        RightStation.SetActive(false);
    }

    public void DisplayLeftUpgrades()
    {
		//Display Western station upgrades
		AttackStation.SetActive(false);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        LeftStation.SetActive(true);
        RightStation.SetActive(false);
    }

    public void DisplayRightUpgrades()
    {
		//Display Eastern station upgrades
		AttackStation.SetActive(false);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        LeftStation.SetActive(false);
        RightStation.SetActive(true);
    }
}
