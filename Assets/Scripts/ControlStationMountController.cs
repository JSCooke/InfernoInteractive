using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlStationMountController : MonoBehaviour {

	public bool allowMovement, allowOffensive, allowDefensive;
	public List<GameObject> movementStations, offensiveStations, defensiveStations;

	public string startingStation;
    public string stationName;

	private string _station;
	public string station {
		get {
			return _station;
		}
		set {
			if (allowMovement) {
				foreach (GameObject station in movementStations) {
					if (station.name == value) {
						_station=station.name;
						setStation (station);
						return;
					}
				}
			}
			if (allowOffensive) {
				foreach (GameObject station in offensiveStations) {
					if (station.name == value) {
						_station=station.name;
						setStation (station);
						return;
					}
				}
			}
			if (allowDefensive) {
				foreach (GameObject station in defensiveStations) {
					if (station.name == value) {
						_station=station.name;
						setStation (station);
						return;
					}
				}
			}
			print("station does not exist or is not allowed here");
		}
	}


	// Use this for initialization
	void Start () {
		station = startingStation;
        //check if the user has set a station
        if(stationName!="" && GameData.get<string>(stationName+" station")!=null) {
            //set the station
            station = GameData.get<string>(stationName + " station");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setStation(GameObject station){
		foreach(Transform child in transform){
			Destroy(child.gameObject);
		}

		GameObject newStation = (GameObject) Instantiate (station, transform.position, transform.rotation);
		newStation.transform.parent = transform;
		newStation.transform.localScale = newStation.transform.parent.localScale;
	}
}
