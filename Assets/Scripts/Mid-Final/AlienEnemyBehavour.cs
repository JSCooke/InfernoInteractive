using UnityEngine;
using System.Collections;

public class AlienEnemyBehavour : Damageable{

    UnityEngine.GameObject tank;
    Transform emp;
    NavMeshAgent navagation;
    bool toEMP = true;

    CapsuleCollider capsuleCollider;

    float timeBetweenAttacks = 0.5f;
    float timer;
    public int attackDamage;

    bool inRange = false;


    // Use this for initialization
    void Start () {

        if (tank == null)
        {
            tank = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
        }
        emp = GameObject.FindGameObjectWithTag("EMP").transform;
        navagation = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        maxHealth = 50;
        currentHealth = maxHealth;

        //depending on difficulty enemies spawn faster
        //easy 2 enemies every 3 sec
        //med 4 enemies every 3 sec
        //hard 6 enemies every 3 sec

        

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

        timer += Time.deltaTime;

        if(timer>=timeBetweenAttacks && inRange && currentHealth > 0)
        {

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

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "PlayerProjectile")
        {
            Destroy(other.gameObject);
        }
    }


    public void TakeDamage (int amount)
    {
        currentHealth -= amount;

        //if dead
        if (currentHealth <= 0)
        {
            //turn to trigger so shots can pass through
            capsuleCollider.isTrigger = true;
        }
    }

    void Attack()
    {
        timer = 0f;
        if(currentHealth > 0)
        {
            //tank.takeDamage(attackDamage);
            //TODO take damage
        }

    }

}
