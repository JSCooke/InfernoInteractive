using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class upgradeSelect : MonoBehaviour {

    public GameObject AttackStation;
    public GameObject DefenseStation;
    public GameObject MovementStation;
    public GameObject LeftStation;
    public GameObject RightStation;

    void Start()
    {
        AttackStation.SetActive(true);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        LeftStation.SetActive(false);
        RightStation.SetActive(false);
    }

    public void DisplayAttackUpgrades()
    {
        AttackStation.SetActive(true);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        LeftStation.SetActive(false);
        RightStation.SetActive(false);
    }

    public void DisplayDefenseUpgrades()
    {
        AttackStation.SetActive(false);
        DefenseStation.SetActive(true);
        MovementStation.SetActive(false);
        LeftStation.SetActive(false);
        RightStation.SetActive(false);
    }

    public void DisplayMovementUpgrades()
    {
        AttackStation.SetActive(false);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(true);
        LeftStation.SetActive(false);
        RightStation.SetActive(false);
    }

    public void DisplayLeftUpgrades()
    {
        AttackStation.SetActive(false);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        LeftStation.SetActive(true);
        RightStation.SetActive(false);
    }

    public void DisplayRightUpgrades()
    {
        AttackStation.SetActive(false);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        LeftStation.SetActive(false);
        RightStation.SetActive(true);
    }
}
