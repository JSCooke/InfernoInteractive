using UnityEngine;
using System.Collections;

public class AlienEnemyBehavour : Damageable{

    public float attackRange;
    public GameObject projectile;

    GameObject player;
    TankController tank;
    Transform tankPosition;


    Transform emp;
    EMPBehaviour empBehave;
    GameObject empObj;


    NavMeshAgent navagation;
    bool toEMP = true;
    
    CapsuleCollider capsuleCollider;

    public float timeBetweenAttacks;
    float timer;

    float speed;

    int attackDamage;
    int easyAttack = 5;
    int medAttack = 10;
    int hardAttack = 15;

    int damageTaken;
    int easyDamageTaken = 50;
    int medDamageTaken = 25;
    int hardDamageTaken = 20;


    int MaxDist = 25;
    int MinDist = 2;



    // Use this for initialization
    void Start () {


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
        
        maxHealth = 100;
        currentHealth = maxHealth;

        int dif = (int)GameData.get<BossController.Difficulty>("difficulty");

        switch (dif)
        {
            case 2:
                damageTaken = easyDamageTaken;
                attackDamage = easyAttack;
                speed = 5f;
                break;
            case 3:
                damageTaken = medDamageTaken;
                attackDamage = medAttack;
                speed = 10f;
                break;
            case 4:
                damageTaken = hardDamageTaken;
                attackDamage = hardAttack;
                speed = 15f;
                break;
            default:    //default easy
                damageTaken = easyDamageTaken;
                attackDamage = easyAttack;
                speed = 5f;
                break;
        }

        //move to emp
        float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, emp.position, step);
        //navagation.SetDestination(emp.position);

    }

    // Update is called once per frame
    void Update () {        

        //check which
        if (toEMP)
        {
            if (Vector3.Distance(transform.position, tankPosition.position) <= MaxDist /*>= MinDist*/)
            {
                toEMP = false;
            }
        }
        else
        {
            //if going to player and player no longer in range
            if (Vector3.Distance(transform.position, tankPosition.position) > MaxDist /*>= MinDist*/)
            {               
                toEMP = true;
            }                       
        }

        if (toEMP)
        {
            transform.forward = Vector3.RotateTowards(transform.forward, emp.position - transform.position, speed * Time.deltaTime, speed * Time.deltaTime);
            float step = speed * Time.deltaTime;
            //if out of range, move towards the target
            if ((transform.position - emp.position).magnitude > attackRange) {
                transform.position = Vector3.MoveTowards(transform.position, emp.position, step);
            } else if (timer >= timeBetweenAttacks) {
                Attack(false);
            }
        }
        else
        {
            transform.forward = Vector3.RotateTowards(transform.forward, tankPosition.position - transform.position, speed * Time.deltaTime, speed * Time.deltaTime);
            float step = speed * Time.deltaTime;
            if ((transform.position - tankPosition.position).magnitude > attackRange) {
                transform.position = Vector3.MoveTowards(transform.position, tankPosition.position, step);
            } else if (timer >= timeBetweenAttacks) {
                Attack(true);
            }
        }

        timer += Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(
            0,
            transform.rotation.eulerAngles.y,
            0));
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


    //public override void OnTriggerStay(Collider other)
    //{
    //    base.OnTriggerStay(other);
    //    if (other.gameObject.tag == "EMP")
    //    {
    //        if (timer >= timeBetweenAttacks && currentHealth > 0)
    //        {
    //            Attack(false);
    //        }
    //    }
    //}

    void Attack(bool isPlayer)
    {
        timer = 0f;
        if(currentHealth > 0)
        {

            if(isPlayer)
            {
                Instantiate(projectile, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(projectile, transform.position, transform.rotation);
            }
        }
    }
}
