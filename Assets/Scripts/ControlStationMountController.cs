using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlStationMountController : MonoBehaviour {

	public bool allowMovement, allowOffensive, allowDefensive;
	public List<UnityEngine.GameObject> movementStations, offensiveStations, defensiveStations;

	public string startingStation;

	private string _station;
	public string station {
		get {
			return _station;
		}
		set {
			if (allowMovement) {
				foreach (UnityEngine.GameObject station in movementStations) {
					if (station.name == value) {
                        _station = station.name;
                        setStation(station);
						return;
					}
				}
			}
			if (allowOffensive) {
				foreach (UnityEngine.GameObject station in offensiveStations) {
					if (station.name == value) {
                        _station = station.name;
                        setStation(station);
						return;
					}
				}
			}
			if (allowDefensive) {
				foreach (UnityEngine.GameObject station in defensiveStations) {
					if (station.name == value) {
                        _station = station.name;
                        setStation(station);
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setStation(UnityEngine.GameObject station){
		foreach(Transform child in transform){
			Destroy(child.gameObject);
		}

        UnityEngine.GameObject newStation = (UnityEngine.GameObject)Instantiate(station, transform.position, transform.rotation);
		newStation.transform.parent = transform;

	}
}
