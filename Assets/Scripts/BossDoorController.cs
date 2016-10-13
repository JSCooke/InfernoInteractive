using UnityEngine;
using System.Collections;

public class BossDoorController : MonoBehaviour {
    public bool open;
    public GameObject leftDoor, rightDoor;
    public float speed, openOffset;
    public bool redOrb = false;
    public bool greenOrb = false;

    private Vector3 leftDoorOpenPosition, rightDoorOpenPosition, leftDoorClosedPosition, rightDoorClosedPosition;
	// Use this for initialization
	void Start () {
        leftDoorClosedPosition = leftDoor.transform.localPosition;
        rightDoorClosedPosition = rightDoor.transform.localPosition;
        leftDoorOpenPosition =
            new Vector3(
                leftDoorClosedPosition.x - openOffset,
                leftDoorClosedPosition.y,
                leftDoorClosedPosition.z);
        rightDoorOpenPosition =
            new Vector3(
                rightDoorClosedPosition.x + openOffset,
                rightDoorClosedPosition.y,
                rightDoorClosedPosition.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (open) {
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, leftDoorOpenPosition, speed * Time.deltaTime);
            rightDoor.transform.localPosition = Vector3.MoveTowards(rightDoor.transform.localPosition, rightDoorOpenPosition, speed * Time.deltaTime);
        } else {
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, leftDoorClosedPosition, speed * Time.deltaTime);
            rightDoor.transform.localPosition = Vector3.MoveTowards(rightDoor.transform.localPosition, rightDoorClosedPosition, speed * Time.deltaTime);
        }
	}

    void OnTriggerEnter()
    {
        if(redOrb && greenOrb)
        {
            open = true;
        }
    }
}
