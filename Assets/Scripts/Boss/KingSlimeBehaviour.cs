using UnityEngine;
using System.Collections;

public class KingSlimeBehaviour : MonoBehaviour {

    public GameObject enemy;
    public GameObject player = null;

    //How many times to duplicate
    public int maxLevel = 2;
    private int currentLevel = 0;
    //Duplicate when reach threshold
    private double threshold = 0.5;

    
    private bool targetAcquired = false;
    private Vector3 playerPosition;

    //Animation of charge attack
    public ParticleSystem chargeParticles;

    //Move randomly when not attacking
    private bool randomMovement = true;
    private Vector3 randomPosition;
    private bool moving = false;


    private Rigidbody rb;

    private bool charging = false;
    private bool dashing = false;
    private bool finding = true;
    private bool roaming = false;

    //Properties of each charge attack
    public double chargeDuration = 3;
    private double chargeStartTime;


    // Use this for initialization
    void Start() {

        chargeParticles.enableEmission = false;
        rb = GetComponent<Rigidbody>();

        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update() {
        
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (this.GetComponent<BossController>().dead) {
            StartCoroutine(Die());
        } else {
            fightPlayer();
        }
        

    }

    void fightPlayer() {
        if (currentLevel < maxLevel && this.GetComponent<BossController>().currentHealth <= this.GetComponent<BossController>().maxHealth * threshold) {
            duplicate();
        }

        if (charging) {
            charge();
        }
        else if (dashing) {
            dashAttack();
        }
        else if (finding) {
            findRandomPosition();
        }
        else if (roaming) {
            roam();
        }
    }

    void charge() {

        chargeParticles.enableEmission = true;

        //Look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(this.transform.position - player.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
        playerPosition = player.transform.position;

        //Finished charging and started attacking
        if (Time.fixedTime > (chargeStartTime + chargeDuration)) {
            dashing = true;
            charging = false;
            chargeParticles.enableEmission = false;
        }

    }

    void dashAttack() {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed);

        if (transform.position == playerPosition) {
            dashing = false;
            finding = true;
        }
    }

    void roam() {

        transform.position = Vector3.MoveTowards(transform.position, randomPosition, 0.2F);

        float chance = Random.Range(0,100);

        //Once finished walking, decide whether to attack or roam again. Rebalance boss here if too hard
        if (transform.position == randomPosition) {

            //Rebalance attack rate here
            if (chance <= 50) {
                randomPosition = Random.insideUnitCircle * 10;
                randomPosition.y = 0;
            } else {
                //rb.velocity = Vector3.zero;
                //rb.angularVelocity = Vector3.zero;

                roaming = false;
                charging = true;
                chargeStartTime = Time.fixedTime;
            }
        }

    }

    void findRandomPosition() {
        
        randomPosition = Random.insideUnitCircle * 10;
        randomPosition.y = 0;

        finding = false;
        roaming = true;
    }

    void OnCollisionEnter(Collision collision) {
        dashing = false;
        finding = true;
    }

    void OnTriggerStay(Collider collider) {
        dashing = false;
        finding = true;
    }

    void duplicate() {

        float offset = (float)0.5;

        //this.GetComponent<BossController>().difficulty
        for (int i = 0; i < 2; i++) {

            Vector3 spawnPoint = this.transform.position;
            offset *= -1;
            spawnPoint.x += offset;
            spawnPoint.z += offset;

            GameObject child = (GameObject)Instantiate(enemy, spawnPoint, Quaternion.identity);
            child.transform.localScale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y / 2, this.transform.localScale.z / 2);

            BossController childScript = child.GetComponent<BossController>();
            childScript.GetComponent<KingSlimeBehaviour>().currentLevel = currentLevel + 1;
            childScript.maxHealth = (int)(this.GetComponent<BossController>().maxHealth * threshold);
            childScript.currentHealth = (int)(this.GetComponent<BossController>().maxHealth * threshold);

        }

        StartCoroutine(Die());
        
    }

    IEnumerator Die() {

        if (this.GetComponent<KingSlimeBehaviour>().currentLevel == maxLevel) {
            Quaternion targetRotation = targetRotation = Quaternion.Euler(new Vector3(90, 45, 0));
            rb.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 2.5F);

            //Wait for 1 second animation to finish
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }


    }

    public void Spawn() {
        Vector3 spawnPoint = player.transform.position;
        spawnPoint.x += 15;
        spawnPoint.y += 15;
        Instantiate(this, spawnPoint, Quaternion.identity);
    }

}
