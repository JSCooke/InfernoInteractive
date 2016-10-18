using UnityEngine;
using System.Collections;

public class MazeUnitController : MonoBehaviour {

	public bool North;
	public bool South;
	public bool East;
	public bool West;

	public GameObject NorthWall;
	public GameObject SouthWall;
	public GameObject EastWall;
	public GameObject WestWall;

	// Use this for initialization
	void Start () {
		if (North) {
			NorthWall.SetActive(true);
		}
		if (South) {
			SouthWall.SetActive(true);
		}
		if (East) {
			EastWall.SetActive(true);
		}
		if (West) {
			WestWall.SetActive(true);
		}
	}
}
