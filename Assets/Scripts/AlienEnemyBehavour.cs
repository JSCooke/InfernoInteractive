using UnityEngine;
using System.Collections;

public class AlienEnemyBehavour : MonoBehaviour {

    UnityEngine.GameObject tank;
    Transform emp;
    NavMeshAgent navagation;
    bool toEMP = true;


    // Use this for initialization
    void Start () {


        if (tank == null)
        {
            tank = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
        }

        emp = GameObject.FindGameObjectWithTag("EMP").transform;

        navagation = GetComponent<NavMeshAgent>();

        //depending on difficulty enemies spawn faster
        //easy 2 enemies every 3 sec
        //med 4 enemies every 3 sec
        //hard 6 enemies every 3 sec


        //Either attack emp or attack tank depending on which is closer?
        //attack emp unless tank is within a certain range

    }
	
	// Update is called once per frame
	void Update () {

        if (toEMP)
        {
            navagation.SetDestination(emp.position);
        }
        else
        {
            navagation.SetDestination(tank.transform.position);
        }
        

    }

    void OnTriggerEnter(Collider other)
    {
        //if player gets in range
        if(other.gameObject.tag == "Player")
        {
            toEMP = false;
        }
        //if player is out of range but emp is in range
        else if( other.gameObject.tag == "EMP")
        {
            toEMP = true;
        }

       
    }

    void OnCollisonStay(Collider col)
    {
        if(col.gameObject.tag == "EMP")
        {
            //attack emp
        }
        else if(col.gameObject.tag == "Player")
        {
            //attack player
        }
        //else if it is a bullet then destroy
    }

}
