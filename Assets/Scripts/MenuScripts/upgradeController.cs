using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class upgradeController : MonoBehaviour {

    public GameObject NorthStation, EastStation, WestStation, CentralStation, SouthStation;

	// Use this for initialization
	void Start () {
        //check which stations has been unlocked
        HashSet<string> unlockedStations = GameData.get<HashSet<string>>("unlocked stations");
        if(unlockedStations == null) {
            unlockedStations = new HashSet<string>();
            unlockedStations.Add("Big Cannon");
            unlockedStations.Add("Machine Gun");
            unlockedStations.Add("Shield");
            unlockedStations.Add("Movement Control");
            GameData.put("unlocked stations", unlockedStations);
        }

        //enable buttons only for stations which have been unlocked
        foreach (Transform t in transform.GetComponentsInChildren<Transform>(true)) {
            if (t.parent.gameObject.name.EndsWith("Station")) {
                print(t.gameObject.name);
                if (unlockedStations.Contains(t.gameObject.name)) {
                    t.gameObject.SetActive(true);
                } else {
                    //Destroy(t.gameObject);
                }
            }
        }
    }

    public void AssignStation(GameObject Upgrade)
    {
        string StationName = Upgrade.transform.parent.name;


        if (StationName == "NorthStation")
        {
            NorthStation.GetComponent<ControlStationMountController>().station = Upgrade.name;
            GameData.put("north station", Upgrade.name);
        } else if (StationName == "EastStation")
        {
            EastStation.GetComponent<ControlStationMountController>().station = Upgrade.name;
            GameData.put("east station", Upgrade.name);
        }
        else if (StationName == "WestStation")
        {
            WestStation.GetComponent<ControlStationMountController>().station = Upgrade.name;
            GameData.put("west station", Upgrade.name);
        }
        else if (StationName == "CentralStation")
        {
            CentralStation.GetComponent<ControlStationMountController>().station = Upgrade.name;
            GameData.put("central station", Upgrade.name);
        }
        else if (StationName == "SouthStation")
        {
            SouthStation.GetComponent<ControlStationMountController>().station = Upgrade.name;
            GameData.put("south station", Upgrade.name);
        }
    } 
   
}
