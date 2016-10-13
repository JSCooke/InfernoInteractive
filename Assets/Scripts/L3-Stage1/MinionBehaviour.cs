using UnityEngine;
using System.Collections;

public class MinionBehaviour : MonoBehaviour {

    public float offset;
    private Rigidbody rb;
    private Vector3 originalPosition;
    private bool moveLeft;
    private float speed = 5f;
    private int difficulty;
    private float startTime;

    void Start () {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        
        //Get level difficulty
        if (GameData.get<BossController.Difficulty>("difficulty") != default(BossController.Difficulty))
        {
            difficulty = (int)GameData.get<BossController.Difficulty>("difficulty");
        }

        //Set movement speed depending on difficulty
        if (difficulty == 2)
        {
            speed = 5f;
        }
        else if (difficulty == 3)
        {
            speed = 10f;
        }
        else
        {
            speed = 15f;
        }

        //Generate random delay time
        startTime = Time.frameCount + Random.Range(0, 500);       
        
    }

    void Update () {
        if (Time.frameCount >= startTime)
        {
            //Checks if the current position has moved further than the offset
            //If so, move in the opposite direction
            if ((transform.position - originalPosition).magnitude > offset)
            {
                moveLeft = !moveLeft;
            }

            //Move left or right depending on the boolean set above
            if (moveLeft)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
}
