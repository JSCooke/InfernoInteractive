using UnityEngine;
using System.Collections;

public class AlienEnemyBehavour : MonoBehaviour {

    Transform tank;
    Transform emp;
    NavMeshAgent navagation;


    // Use this for initialization
    void Start () {


        tank = GameObject.FindGameObjectWithTag("Player").transform;
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

        navagation.SetDestination(emp.position);
        //navagation.SetDestination(tank.position);

    }

    void movement()
    {

    }


}
