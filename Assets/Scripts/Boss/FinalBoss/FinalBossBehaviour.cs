using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinalBossBehaviour : Spawnable {

    public GameObject player;
    private Vector3 playerPosition;

    private Rigidbody rb;
    private float currentHealth, maxHealth;

    public GameObject shield;

    //Different types of skills
    public enum Action {
        STATIONARY,
        SHIELD,
        METEOR,
        SNARE,
        SLAM
    };

    private Animator anim;

    public bool newAction;
    private Queue lastSkillsUsed = new Queue();

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        
        maxHealth = this.GetComponent<BossController>().maxHealth;
        currentHealth = maxHealth;

        if (player == null) {
            player = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
        }

        anim = this.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (Time.timeScale == 0) {
            return;
        }

        currentHealth = this.GetComponent<BossController>().currentHealth;

        if (this.GetComponent<BossController>().dead) {
            Die();
        }
        else {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - this.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
            fightPlayer();
        }

    }

    void updateQueue(Action action) {

        if (lastSkillsUsed.Count == 2) {
            lastSkillsUsed.Dequeue();
        }
        
        lastSkillsUsed.Enqueue(action);
    }

    void fightPlayer() {

        if (newAction) {

            newAction = false;
            float randSkill = Random.Range(0, 100);
            randSkill = 30;

            if (randSkill <= 30 && !lastSkillsUsed.Contains(Action.SLAM)) {  //Slam
                print("Slam");
                updateQueue(Action.SLAM);
                anim.SetBool("Slam", true);

            } else if (randSkill <= 40 && currentHealth <= 25 && !lastSkillsUsed.Contains(Action.SHIELD)) {     //Shield
                print("Shield");
                updateQueue(Action.SHIELD);
                anim.SetBool("Meteor", true);

            } else if (randSkill <= 50 && currentHealth <= 50 && !lastSkillsUsed.Contains(Action.METEOR)) {     //Meteor
                print("Meteor");
                updateQueue(Action.METEOR);
                anim.SetBool("Shield", true);

            } else if (randSkill <= 60 && currentHealth <= 75 && !lastSkillsUsed.Contains(Action.SNARE)) {     //Snare
                print("Snare");
                updateQueue(Action.SNARE);
                anim.SetBool("Snare", true);

            } else {     //Stationary
                print("Stationary");
                //anim.SetBool("Stationary", true);
                anim.SetBool("Meteor", true);
            }

        }

    }

    void Die() {

        anim.SetBool("Dead", true);

        //Wait 1 second for animation to finish
        Destroy(this.gameObject);
    }

}

//Create shockwave object. Reset newaction when collide