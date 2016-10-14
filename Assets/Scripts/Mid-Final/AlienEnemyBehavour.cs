using UnityEngine;
using System.Collections;

public class AlienEnemyBehavour : Damageable{

    GameObject player;
    TankController tank;
    Transform tankPosition;


    Transform emp;
    EMPBehaviour empBehave;
    GameObject empObj;


    NavMeshAgent navagation;
    bool toEMP = true;

    public ParticleSystem chargeParticles;

    CapsuleCollider capsuleCollider;

    float timeBetweenAttacks = 0.5f;
    float timer;

    int attackDamage;
    int easyAttack = 5;
    int medAttack = 10;
    int hardAttack = 15;

    int damageTaken;
    int easyDamageTaken = 50;
    int medDamageTaken = 25;
    int hardDamageTaken = 20;


    int MaxDist = 25;
    int MinDist = 1;
    bool playerInRange = false;



    // Use this for initialization
    void Start () {

        //TODO fix so that get proper player

        if (player == null)
        {
            player = GameObject.Find("Tank");
        }

        tankPosition = player.transform;
        tank = player.GetComponent<TankController>();

        empObj = GameObject.Find("EMP");
        emp = empObj.transform;
        empBehave = empObj.GetComponent<EMPBehaviour>();

        navagation = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        chargeParticles.enableEmission = false;

        maxHealth = 100;
        currentHealth = maxHealth;

        int dif = (int)GameData.get<BossController.Difficulty>("difficulty");

        switch (dif)
        {
            case 2:
                damageTaken = easyDamageTaken;
                attackDamage = easyAttack;
                break;
            case 3:
                damageTaken = medDamageTaken;
                attackDamage = medAttack;
                break;
            case 4:
                damageTaken = hardDamageTaken;
                attackDamage = hardAttack;
                break;
            default:    //default easy
                damageTaken = easyDamageTaken;
                attackDamage = easyAttack;
                break;

        }
        
    }
	
	// Update is called once per frame
	void Update () {

        //check if close to tank
        transform.LookAt(tankPosition);

        if (toEMP)
        {
            if (Vector3.Distance(transform.position, tankPosition.position) <= MaxDist /*>= MinDist*/)
            {
                toEMP = false;
                playerInRange = true;
            }

        }
        else
        {
            //if going to player and player no longer in range
            if (Vector3.Distance(transform.position, tankPosition.position) > MaxDist /*>= MinDist*/)
            {               
                toEMP = true;
                playerInRange = false;

            }


            
        }

        

        


        //if (Vector3.Distance(transform.position, player.transform.position) <= MaxDist)
        //{
            
        //    player.GetComponent<TankController>().takeDamage(4);

        //}

        if (toEMP)
        {
            navagation.SetDestination(emp.position);
        }
        else
        {
            navagation.SetDestination(tankPosition.position);
        }

        timer += Time.deltaTime;
        
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

    void OnCollisionStay(Collision collisionInfo)
    {
       if(collisionInfo.gameObject.tag == "Player" || collisionInfo.gameObject.tag == "EMP")
        {           
            if (timer >= timeBetweenAttacks && currentHealth > 0)
            {
                if (collisionInfo.gameObject.tag == "Player")
                {
                    Debug.Log("en attack player");
                    Attack(true);
                    //attack plauer
                }
                else if (collisionInfo.gameObject.tag == "EMP")
                {
                    Debug.Log("en attack emp");
                    Attack(false);
                    //attack emp
                }
            }
        }  
    }



    void OnTriggerExit(Collider other)
    {
        //TODO
        //check if collider calling is a coluumn or a sphere collider
        //if col check projectile

        if (other.gameObject.tag == "PlayerProjectile")
        {
            takeDamage(damageTaken);
            Destroy(other.gameObject);
        }
    }


    void takeDamage (int amount)
    {
        currentHealth = currentHealth - amount;

        //if dead
        if (currentHealth <= 0)
        {
            dead = true;
            Destroy(gameObject);
            //turn to trigger so shots can pass through
            capsuleCollider.isTrigger = true;
        }
    }

    void Attack(bool isPlayer)
    {
        timer = 0f;
        if(currentHealth > 0)
        {
            chargeParticles.enableEmission = true;

            if(isPlayer)
            {
                tank.takeDamage(attackDamage);
            }
            else
            {
                empBehave.takeDamage(1);
            }

        }
        chargeParticles.enableEmission = false;

    }

}
