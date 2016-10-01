using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
    public GameObject tankBase;
    public float acceleration, drag, topSpeed;
    public bool canMove = true;

    private float speed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (canMove)
        {
            if (speed > 0)
            {
                speed = Mathf.Max(speed - drag * Time.deltaTime, 0);
            }
            else if (speed < 0)
            {
                speed = Mathf.Min(speed + drag * Time.deltaTime, 0);
            }
            transform.Translate(tankBase.transform.forward * (speed * Time.deltaTime));
        }
    }

    public void accelerate() {
        if (canMove)
        {
           
            speed = Mathf.Min(speed + acceleration * Time.deltaTime, topSpeed);
        }
    }

    public void decelerate() {
        if (canMove)
        {
            speed = Mathf.Max(speed - acceleration * Time.deltaTime, -topSpeed);
        }
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
