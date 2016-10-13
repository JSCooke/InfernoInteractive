using UnityEngine;
using System.Collections;

public class TeleportController : MonoBehaviour {

	public int gotoX;
	public int gotoY;
	public int gotoZ;

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			other.transform.position = new Vector3(gotoX, gotoY, gotoZ);
		}
	}
	
}
