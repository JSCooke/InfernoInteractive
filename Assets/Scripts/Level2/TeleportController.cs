using UnityEngine;
using System.Collections;

public class TeleportController : MonoBehaviour {

	public int gotoX;
	public int gotoY;
	public int gotoZ;

	public GameObject tank;

	public void OnTriggerEnter() {
		tank.transform.position = new Vector3(gotoX, gotoY, gotoZ);
	}
	
}
