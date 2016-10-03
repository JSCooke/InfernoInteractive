using UnityEngine;
using System.Collections;

public class KingSlimeBehaviour : MonoBehaviour {

    public GameObject enemy;
    public GameObject player = null;

    //How many times to duplicate
    public int maxLevel = 2;
    public int currentLevel = 0;
    //Duplicate when reach threshold
    private double threshold = 0.5;

    private Vector3 playerPosition;

    //Animation of charge attack
    public ParticleSystem chargeParticles;

    //Move randomly when not attacking
    private Vector3 randomPosition;

    private Rigidbody rb;

    private bool charging = false;
    private bool dashing = false;
    private bool finding = true;
    private bool roaming = false;

    //Properties of each charge attack
    public double chargeDuration = 3;
    private double chargeStartTime;

    private int currentHealth, maxHealth;

    // Use this for initialization
    void Start() {

        chargeParticles.enableEmission = false;
        rb = GetComponent<Rigidbody>();

        maxHealth = this.GetComponent<BossController>().maxHealth;
        currentHealth = maxHealth;

        if (player == null) {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
    }

    // Update is called once per frame
    void Update() {

        if (Time.timeScale == 0) {
            return;
        }

        currentHealth = this.GetComponent<BossController>().currentHealth;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (this.GetComponent<BossController>().dead) {
            StartCoroutine(Die());
        } else {
            //fightPlayer();
        }
        

    }

    void fightPlayer() {
        currentHealth = GetComponent<BossController>().currentHealth;
        maxHealth = GetComponent<BossController>().maxHealth;

        if (currentLevel < maxLevel && currentHealth <= 0) {
            duplicate();
        }

        if (charging) {
            //print("charging");
            charge();
        }
        else if (dashing) {
            //print("dashing");
            dashAttack();
        }
        else if (finding) {
            //print("finding");
            findRandomPosition();
        }
        else if (roaming) {
            //print("roaming");
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
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime * 2);

        if (transform.position == playerPosition) {
            dashing = false;
            finding = true;
        }
    }

    void roam() {

        transform.position = Vector3.MoveTowards(transform.position, randomPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime);

        float chance = Random.Range(0,100);

        //Once finished walking, decide whether to attack or roam again. Rebalance boss here if too hard
        if (transform.position == randomPosition) {

            //Rebalance attack rate here
            if (chance <= 80) {
                randomPosition = Random.insideUnitCircle * 10;
                randomPosition.y = 0;
                randomPosition.x += transform.position.x;
                randomPosition.z += transform.position.z;
            } else {

                roaming = false;
                charging = true;
                chargeStartTime = Time.fixedTime;
            }
        }

    }

    void findRandomPosition() {
        
        randomPosition = Random.insideUnitCircle * 10;
        randomPosition.y = 0;
        randomPosition.x += transform.position.x;
        randomPosition.z += transform.position.z;

        finding = false;
        roaming = true;
    }

    void OnCollisionEnter(Collision collision) {

        string collidedTag = collision.gameObject.tag;
        if (collidedTag == "Player" || collidedTag == "KingSlime") {
            dashing = false;
            finding = true;
        }
        
    }

    void OnTriggerStay(Collider collider) {
        string collidedTag = collider.gameObject.tag;
        if (collidedTag == "Player" || collidedTag == "KingSlime") {
            dashing = false;
            finding = true;
        }

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
            childScript.maxHealth = (int)(maxHealth * threshold);
            childScript.currentHealth = childScript.maxHealth;

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
