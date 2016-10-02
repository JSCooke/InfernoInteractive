using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class upgradeSelect : MonoBehaviour {

	public GameObject Transform;
    public GameObject UpgradePanel;

    //public Text[] attackNames;
    //public Text[] defenseNames;
    //public Text[] otherNames;

    public Upgrade[] attackUpgrades = new Upgrade[2];
    public Upgrade[] defenseUpgrades = new Upgrade[1];
    public Upgrade[] movementUpgrades = new Upgrade[1];
    public Upgrade[] otherUpgrades = new Upgrade[1];

    void Start()
    {
        FillAttackList();
        FillDefenseList();
        FillMovementList();
        FillOtherList();
    }


    public void DisplayAttackUpgrades()
    {
        for (int i = 0; i < attackUpgrades.Length; i++)
        {
            
        }
    }

    public void DisplayDefenseUpgrades()
    {
        for (int i = 0; i < defenseUpgrades.Length; i++)
        {
           
        }
    }

    public void DisplayMovementUpgrades()
    {
        for (int i = 0; i < movementUpgrades.Length; i++)
        {
            
        }
    }

    public void DisplayOtherUpgrades()
    {
        for (int i = 0; i < otherUpgrades.Length; i++)
        {
           
        }
    }

    void FillAttackList()
    {
        attackUpgrades[0] = new Upgrade();
        attackUpgrades[0].Name = "Cannon";

        attackUpgrades[1] = new Upgrade();
        attackUpgrades[1].Name = "Chainsaw";
    }

    void FillDefenseList()
    {
        defenseUpgrades[0] = new Upgrade();
        defenseUpgrades[0].Name = "Shield";
    }

    void FillMovementList()
    {
        
    }

    void FillOtherList()
    {
        otherUpgrades[0] = new Upgrade();
        otherUpgrades[0].Name = "Ray Gun";
    }

    public class Upgrade
    {
        public int StationType;
        public string Name;
        public Image Image;
        public GameObject WeaponObject;
    }

}
