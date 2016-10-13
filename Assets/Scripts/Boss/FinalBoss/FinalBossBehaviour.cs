using UnityEngine;
using System.Collections;

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
    private bool charging, dashing;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();

        maxHealth = this.GetComponent<BossController>().maxHealth;
        currentHealth = maxHealth;

        if (player == null) {
            player = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
        }
        
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

                randomNextAction(true);
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

    public void randomNextAction(bool newAction) {

        if (newAction) {
            randSkill = Random.Range(0, 100);
        }

        if (randSkill <= 40) {  //Stationary

            currentAction = Action.STATIONARY;

        } else if(randSkill <= 50) {     //Shield

            currentAction = Action.SHIELD;

        } else if (randSkill <= 60) {     //Meteor

            currentAction = Action.METEOR;

        } else if (randSkill <= 70) {     //Snare

            currentAction = Action.SNARE;
        } else if (randSkill <= 100) {     //Attack
            
            charging = true;
            currentAction = Action.DEFAULT_ATTACK;
            
        }

        print(currentAction);
    }

    void attack() {
        
        if (charging) {
            charge();
        }
        else if (dashing) {
            dashAttack();
        }
    }

    void charge() {

        //Look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - this.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
        playerPosition = player.transform.position;

        //Finished charging and started attacking
        if (Time.fixedTime > (chargeStartTime + chargeDuration)) {
            dashing = true;
            charging = false;
        }

    }

    void dashAttack() {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime * 6);

        if (transform.position == playerPosition) {
            dashing = false;
            currentAction = Action.STATIONARY;
        }
    }

    void OnCollisionEnter(Collision collision) {

        string collidedTag = collision.gameObject.tag;

        if (collidedTag == "Player") {
            dashing = false;
            currentAction = Action.STATIONARY;
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
