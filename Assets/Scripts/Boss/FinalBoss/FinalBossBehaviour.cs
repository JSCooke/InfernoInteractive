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
    public Dictionary<string, float> animationTimes = new Dictionary<string, float>();
    public Animator anim;

    public float topPause = 1f;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        
        maxHealth = this.GetComponent<BossController>().maxHealth;
        currentHealth = maxHealth;

        if (player == null) {
            player = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
        }

        //Add animation times to dictionary
        animationTimes["Attack"] = 1.8f;
        animationTimes["Dead"] = 1.0f;
        animationTimes["Idle"] = 1.0f;
        animationTimes["Roar"] = 1.0f;
        animationTimes["Run"] = 1.0f;
        animationTimes["Spawn"] = 3.8f;

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
            StartCoroutine(Die());
        }
        else {
            fightPlayer();
        }


    }

    void fightPlayer() {

        switch (currentAction) {

            case Action.STATIONARY:
                
                //Spawning is done
                if (Time.fixedTime > animationTimes["Spawn"]) { 
                    returnToTop();
                }
                
                break;

            case Action.SHIELD:

                resetAnimator();

                if (Time.fixedTime - chargeStartTime > chargeDuration) {
                    skills[0].SetActive(true);
                } else {
                    anim.SetBool("Roar", true);
                }
                
                break;

            case Action.METEOR:

                resetAnimator();

                if (Time.fixedTime - chargeStartTime > chargeDuration) {
                    skills[1].SetActive(true);
                }
                else {
                    anim.SetBool("Roar", true);
                }
                break;

            case Action.SNARE:

                resetAnimator();

                if (Time.fixedTime - chargeStartTime > chargeDuration) {
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

        resetAnimator();
        anim.SetBool("Run", true);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(this.transform.position - player.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, topPosition.transform.position, this.GetComponent<BossController>().bossSpeed * Time.deltaTime);

        if (transform.position == topPosition.transform.position) {
            transform.LookAt(player.transform);

            resetAnimator();
            anim.SetBool("Idle", true);



            if (UIAdapter.getTimeInSeconds() - chargeStartTime > topPause) {
                resetAnimator();
                randomNextAction(true);
            }
            
        }

    }

    public void randomNextAction(bool newAction) {

        if (newAction) {
            randSkill = Random.Range(0, 100);
            chargeStartTime = UIAdapter.getTimeInSeconds();

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
                currentAction = Action.DEFAULT_ATTACK;

            }
        }

        currentAction = Action.SHIELD;

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
            chargeStartTime = UIAdapter.getTimeInSeconds();
        } else {
            //Look at the player
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - this.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
            playerPosition = player.transform.position;
        }

    }

    void dashAttack() {

        resetAnimator();
        anim.SetBool("Run", true);

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime * 3);

        if (transform.position == playerPosition) {

            resetAnimator();
            anim.SetBool("Attack", true);


            if (UIAdapter.getTimeInSeconds() - chargeStartTime > animationTimes["Attack"]) {
                dashing = false;
                currentAction = Action.STATIONARY;
            }
            
        }
    }

    void OnCollisionEnter(Collision collision) {

        string collidedTag = collision.gameObject.tag;

        if (collidedTag == "Player") {

            resetAnimator();
            anim.SetBool("Attack", true);

            if (UIAdapter.getTimeInSeconds() - chargeStartTime > animationTimes["Attack"]) {
                dashing = false;
                currentAction = Action.STATIONARY;
            }
        }

    }

    IEnumerator Die() {

        resetAnimator();
        anim.SetBool("Dead", true);

        //Wait 1 second for animation to finish
        yield return new WaitForSeconds(1);
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
