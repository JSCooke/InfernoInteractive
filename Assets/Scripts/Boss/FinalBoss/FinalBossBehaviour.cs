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
        animationTimes["Dead"] = 1;
        animationTimes["Idle"] = 1;
        animationTimes["Roar"] = 1;
        animationTimes["Run"] = 1;
        animationTimes["Spawn"] = 3.8f;

        anim = this.gameObject.GetComponent<Animator>();

        currentAction = Action.STATIONARY;

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

                skills[0].SetActive(true);
                break;

            case Action.METEOR:

                skills[1].SetActive(true);
                break;

            case Action.SNARE:

                skills[2].SetActive(true);

                break;

            case Action.DEFAULT_ATTACK:

                attack();
                break;
            
        }

    }

    void returnToTop() {

        anim.SetBool("Run", true);
        anim.SetBool("Attack", false);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(this.transform.position - player.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, topPosition.transform.position, this.GetComponent<BossController>().bossSpeed * Time.deltaTime);

        if (transform.position == topPosition.transform.position) {
            transform.LookAt(player.transform);

            anim.SetBool("Run", false);
            anim.SetBool("Idle", true);

            if (UIAdapter.getTimeInSeconds() - chargeStartTime > topPause) {
                anim.SetBool("Idle", false);
                randomNextAction(true);
            }
            
        }

    }

    public void randomNextAction(bool newAction) {

        if (newAction) {
            randSkill = Random.Range(0, 100);

            if (randSkill <= 40) {  //Stationary
                chargeStartTime = UIAdapter.getTimeInSeconds();
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

        anim.SetBool("Run", true);

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime * 3);

        if (transform.position == playerPosition) {

            anim.SetBool("Attack", true);
            anim.SetBool("Run", false);
            

            if (UIAdapter.getTimeInSeconds() - chargeStartTime > animationTimes["Attack"]) {
                dashing = false;
                currentAction = Action.STATIONARY;
            }
            
        }
    }

    void OnCollisionEnter(Collision collision) {

        string collidedTag = collision.gameObject.tag;

        if (collidedTag == "Player") {

            anim.SetBool("Attack", true);
            anim.SetBool("Run", false);

            if (UIAdapter.getTimeInSeconds() - chargeStartTime > animationTimes["Attack"]) {
                dashing = false;
                currentAction = Action.STATIONARY;
            }
        }

    }

    IEnumerator Die() {
        Quaternion targetRotation = Quaternion.Euler(new Vector3(90, 45, 0));
        rb.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 2.5F);

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
