using UnityEngine;
using System.Collections;

public class AlienEnemyBehavour : Damageable{

    TankController player;
    UnityEngine.GameObject tank;
    Transform emp;
    public EMPBehaviour empObj;
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
    int easyDamageTaken = 100;
    int medDamageTaken = 50;
    int hardDamageTaken = 25;



    // Use this for initialization
    void Start () {

        if (tank == null)
        {
            tank = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
            player = tank.GetComponent<TankController>();
        }



        emp = empObj.transform;


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
        }
        
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

        if (other.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log("en got hit");
            Destroy(other.gameObject);
            takeDamage(damageTaken);
            //Destroy(other.gameObject);
        }
    }


    void takeDamage (int amount)
    {
        currentHealth -= amount;

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
                player.takeDamage(attackDamage);
            }
            else
            {
                empObj.takeDamage(attackDamage);
            }
            
            
            //TODO take damage
        }
        chargeParticles.enableEmission = false;

    }

}
