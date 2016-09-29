using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
    public GameObject tankBase;
    public float acceleration, drag, topSpeed;

    private float speed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (speed > 0) {
            speed = Mathf.Max(speed - drag * Time.deltaTime, 0);
        }else if (speed < 0) {
            speed = Mathf.Min(speed + drag * Time.deltaTime, 0);
        }
        transform.Translate(tankBase.transform.forward * (speed * Time.deltaTime));
    }

    public void accelerate() {
        speed = Mathf.Min(speed + acceleration * Time.deltaTime, topSpeed);
    }

    public void decelerate() {
        speed = Mathf.Max(speed - acceleration * Time.deltaTime, -topSpeed);
    }
}
