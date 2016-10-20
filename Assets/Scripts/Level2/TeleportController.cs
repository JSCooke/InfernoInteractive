using UnityEngine;
using System.Collections;

public class TeleportController : MonoBehaviour {

	public int gotoX;
	public int gotoY;
	public int gotoZ;

	public bool isHole = false;

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			other.GetComponentInParent<TankController>().transform.position = new Vector3(gotoX, gotoY, gotoZ);
			other.GetComponentInParent<TankController>().transform.rotation = Quaternion.identity;
			other.transform.Find("Treads").gameObject.transform.rotation = Quaternion.identity;
			other.GetComponentInParent<TankController>().GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

			//fail the achievement
			if (isHole) {
				AchievementController.hasFailedBoxStage = true;
			}

		}
	}
	
}
