using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinalBossBehaviour : Spawnable {

    public GameObject player;
    private Vector3 playerPosition;

    private Rigidbody rb;
    private float currentHealth, maxHealth;

    private float randSkill;
    public GameObject[] skills = new GameObject[3];

    //Different types of skills
    public enum Action {
        STATIONARY,
        SHIELD,
        METEOR,
        SNARE,
        DEFAULT_ATTACK
    };

    //Change to private
    public Action currentAction;

    //Properties of each default attack
    public double chargeDuration = 3;
    private double chargeStartTime;
    private bool charging = true, dashing;

    public GameObject topPosition;
    public Dictionary<string, int> animationTimes = new Dictionary<string, int>();
    public Animator anim;

    public int frameCount = 0;
    public float topPause = 1f;
    private int delay = 20;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        
        maxHealth = this.GetComponent<BossController>().maxHealth;
        currentHealth = maxHealth;

        if (player == null) {
            player = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
        }

        //Add animation times to dictionary
        animationTimes["Attack"] = 25 + delay;
        animationTimes["Dead"] = 27 + delay;
        animationTimes["Idle"] = 58 + delay;
        animationTimes["Roar"] = 47 + delay;
        animationTimes["Run"] = 28 + delay;
        animationTimes["Spawn"] = 52 + delay;
        //animationTimes["Attack"] = 115;
        //animationTimes["Dead"] = 115;
        //animationTimes["Idle"] = 220;
        //animationTimes["Roar"] = 200;
        //animationTimes["Run"] = 115;
        //animationTimes["Spawn"] = 220;

        anim = this.gameObject.GetComponent<Animator>();

        resetAnimator();

        currentAction = Action.STATIONARY;

    }

    public void resetAnimator() {
        anim.SetBool("Attack", false);
        anim.SetBool("Dead", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Roar", false);
        anim.SetBool("Run", false);
        anim.SetBool("Spawn", false);
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
            fightPlayer();
        }


    }

    void fightPlayer() {

        frameCount++;
        
        switch (currentAction) {
            
            case Action.STATIONARY:

                //Spawning is done
                if (frameCount > animationTimes["Spawn"]) {
                    animationTimes["Spawn"] = -1;

                    if (!anim.GetBool("Run") && !anim.GetBool("Idle")) {
                        frameCount = 0;
                    }
                    
                    returnToTop();
                }
                
                break;

            case Action.SHIELD:
                print(frameCount);
                resetAnimator();

                if (frameCount > animationTimes["Roar"]) {
                    skills[0].SetActive(true);
                } else {
                    anim.SetBool("Roar", true);
                }
                
                break;

            case Action.METEOR:

                resetAnimator();

                if (frameCount > animationTimes["Roar"]) {
                    skills[1].SetActive(true);
                }
                else {
                    anim.SetBool("Roar", true);
                }
                break;

            case Action.SNARE:
                print(frameCount);
                resetAnimator();

                if (frameCount > animationTimes["Roar"]) {

                    skills[2].SetActive(true);

                }
                else {
                    anim.SetBool("Roar", true);
                }

                break;

            case Action.DEFAULT_ATTACK:

                attack();
                break;
            
        }

    }

    void returnToTop() {

        //print("top");
        resetAnimator();
        anim.SetBool("Run", true);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(this.transform.position - player.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, topPosition.transform.position, this.GetComponent<BossController>().bossSpeed * Time.deltaTime);

        if (transform.position == topPosition.transform.position) {

            resetAnimator();
            anim.SetBool("Idle", true);
            transform.LookAt(player.transform);

            if (frameCount > animationTimes["Idle"]) {
                resetAnimator();
                randomNextAction(true);
            }
            
        } else {
            frameCount = 0;
        }

    }

    public void randomNextAction(bool newAction) {

        if (newAction) {
            randSkill = Random.Range(0, 100);

            if (randSkill <= 40) {  //Stationary
                
                currentAction = Action.STATIONARY;

            }
            else if (randSkill <= 50 && currentHealth <= 50) {     //Shield

                currentAction = Action.SHIELD;

            }
            else if (randSkill <= 60 && currentHealth <= 25) {     //Meteor

                currentAction = Action.METEOR;

            }
            else if (randSkill <= 70 && currentHealth <= 75) {     //Snare

                currentAction = Action.SNARE;
                skills[2].GetComponent<Snare>().startTime = UIAdapter.getTimeInSeconds();

            }
            else {     //Attack

                charging = true;
                chargeStartTime = UIAdapter.getTimeInSeconds();
                currentAction = Action.DEFAULT_ATTACK;

            }
        }

        print(currentAction);   
        frameCount = 0;

    }

    void attack() {

        if (charging) {
            charge();
        } else if (dashing) {
            dashAttack();
        }
    }

    void charge() {

        //Finished charging and started attacking
        if (UIAdapter.getTimeInSeconds() > (chargeStartTime + chargeDuration)) {
            dashing = true;
            charging = false;
            frameCount = 0;
        } else {
            //Look at the player
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - this.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
            playerPosition = player.transform.position;
        }

    }

    void dashAttack() {

        if (transform.position == playerPosition) {

            resetAnimator();
            anim.SetBool("Attack", true);

            if (frameCount > animationTimes["Attack"]) {
                dashing = false;
                currentAction = Action.STATIONARY;
            }
            
        } else {
            resetAnimator();
            anim.SetBool("Run", true);

            transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime * 3);
            frameCount = 0;
        }
    }

    void OnCollisionEnter(Collision collision) {

        string collidedTag = collision.gameObject.tag;

        if (collidedTag == "Player") {

            resetAnimator();
            anim.SetBool("Attack", true);

            if (frameCount > animationTimes["Attack"]) {
                dashing = false;
                currentAction = Action.STATIONARY;
            }
        }

    }

    void Die() {

        resetAnimator();
        //anim.SetBool("Dead", true);

        //Wait 1 second for animation to finish
        Destroy(this.gameObject);
    }

    public GameObject getSkill(Action action) {

        for (int i = 0; i < skills.Length; i++) {
            print(skills[0].GetComponent<SkillController>().action);
            print(action);
            if (skills[0].GetComponent<SkillController>().action == action) {
                return skills[0];
            }
        }

        return null;
    }
}
