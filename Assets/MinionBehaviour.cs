using UnityEngine;
using System.Collections;

public class MinionBehaviour : MonoBehaviour {

    public float offset;
    private Rigidbody rb;
    private Vector3 originalPosition;
    private bool moveLeft;

    void Start () {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
	}
    
    void Update () {

        //Checks if the current position has moved further than the offset
        //If so, move in the opposite direction
        if ((transform.position - originalPosition).magnitude > offset)
        {
            moveLeft = !moveLeft;
        }
            
        //Move left or right depending on the boolean set above
        if(moveLeft)
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }
            
	}
}
