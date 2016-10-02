using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class upgradeSelect : MonoBehaviour {

    public GameObject AttackStation;
    public GameObject DefenseStation;
    public GameObject MovementStation;
    public GameObject OtherStation;

    void Start()
    {
        //AttackStation = AttackStation.GetComponent<Image>();
        //DefenseStation = DefenseStation.GetComponent<Image>();
        //MovementStation = MovementStation.GetComponent<Image>();
        //OtherStation = OtherStation.GetComponent<Image>();

        AttackStation.SetActive(true);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        OtherStation.SetActive(false);
    }

    public void DisplayAttackUpgrades()
    {
        AttackStation.SetActive(true);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        OtherStation.SetActive(false);
    }

    public void DisplayDefenseUpgrades()
    {
        AttackStation.SetActive(false);
        DefenseStation.SetActive(true);
        MovementStation.SetActive(false);
        OtherStation.SetActive(false);
    }

    public void DisplayMovementUpgrades()
    {
        AttackStation.SetActive(false);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(true);
        OtherStation.SetActive(false);
    }

    public void DisplayOtherUpgrades()
    {
        AttackStation.SetActive(false);
        DefenseStation.SetActive(false);
        MovementStation.SetActive(false);
        OtherStation.SetActive(true);
    }
}
