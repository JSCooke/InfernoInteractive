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

    }


    public void DisplayAttackUpgrades()
    {
        Instantiate(UpgradePanel, new Vector3(transform.position.x, transform.position.y), new Quaternion());
    }

    public void DisplayDefenseUpgrades()
    {

    }

    public void DisplayMovementUpgrades()
    {

    }

    public void DisplayOtherUpgrades()
    {

    }

    public class Upgrade
    {
        public int StationType;
        public string Name;
        public Image Image;
        public GameObject WeaponObject;
    }

}
