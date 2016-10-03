using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class upgradeController : MonoBehaviour {

    public GameObject NorthStation, EastStation, WestStation, CentralStation, SouthStation;

	// Use this for initialization
	void Start () {
	
	}

    public void AssignStation(GameObject Upgrade)
    {
        string StationName = Upgrade.transform.parent.name;
        print("UpgradeName " + Upgrade.name);
        print("StationName " + StationName);

        if (StationName == "NorthStation")
        {
            NorthStation.GetComponent<ControlStationMountController>().station = Upgrade.name;
        } else if (StationName == "EastStation")
        {
            EastStation.GetComponent<ControlStationMountController>().station = Upgrade.name;
        }
        else if (StationName == "WestStation")
        {
            WestStation.GetComponent<ControlStationMountController>().station = Upgrade.name;
        }
        else if (StationName == "CentralStation")
        {
            CentralStation.GetComponent<ControlStationMountController>().station = Upgrade.name;
        }
        else if (StationName == "SouthStation")
        {
            SouthStation.GetComponent<ControlStationMountController>().station = Upgrade.name;
        }
    } 
   
}
