using UnityEngine;
using System.Collections;

public class KingSlimeBehaviour : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;

    //How many times to duplicate
    public int maxLevel = 2;
    private int currentLevel = 0;
    //Duplicate when reach threshold
    private double threshold = 0.5;

    //Properties of each charge attack
    public double chargeDuration = 3;
    //Give players at least 5 seconds to prepare
    private double chargeStartTime = 5;
    private bool targetAcquired = false;
    private Vector3 playerPosition;

    //Animation of charge attack
    public ParticleSystem chargeParticles;

    //Move randomly when not attacking
    private bool randomMovement = true;
    private Vector3 randomPosition;
    private bool moving = false;

    // Use this for initialization
    void Start() {
        IEnumerator landing = WaitForLanding();
        StartCoroutine(landing);

        chargeParticles.enableEmission = false;

        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    IEnumerator WaitForLanding() {

        while (transform.position.y > 0) {
            yield return null;
        }

    }

    // Update is called once per frame
    void Update() {

        if (currentLevel < maxLevel && this.GetComponent<BossController>().currentHealth <= this.GetComponent<BossController>().maxHealth * threshold) {
            duplicate();
        }

        if (randomMovement) {
            wander();
        }
        else {
            chargeAttack();
        }

    }

    void chargeAttack() {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(this.transform.position - player.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);

        //Attack when ready and not already attacking. Rebalance here if boss too hard
        if (Random.value < this.GetComponent<BossController>().difficulty / 50 && !targetAcquired && Time.fixedTime > (chargeStartTime + chargeDuration)) {
            targetAcquired = true;
            playerPosition = player.transform.position;
            chargeParticles.enableEmission = false;
        }

        if (targetAcquired) {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed);

            if (transform.position == playerPosition) {
                targetAcquired = false;
                //chargeStartTime = Time.fixedTime;
                randomMovement = true;
            }

        }
    }

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "Player") {
            targetAcquired = false;
            //chargeStartTime = Time.fixedTime;
            randomMovement = true;
        }
    }

    void OnTriggerStay(Collider collider) {

        if (collider.gameObject.tag == "Player") {
            targetAcquired = false;
            //chargeStartTime = Time.fixedTime;
            randomMovement = true;
        }
    }

    void wander() {

        if (!moving) {
            moving = true;
            randomPosition = Random.insideUnitCircle * 2;
            randomPosition.y = 0;
        }

        if (moving) {

            transform.position = Vector3.MoveTowards(transform.position, randomPosition, 0.1F);

            if (transform.position == randomPosition) {
                float chance = Random.value;

                //Once finished moving to random position, decide whether to move randomly again or attack
                if (chance <= 0.01F) {
                    moving = false;
                }
                else if (chance <= 0.02F) {
                    randomMovement = false;
                    chargeStartTime = Time.fixedTime;
                    chargeParticles.enableEmission = true;
                }
            }

        }
    }

    void duplicate() {

        for (int i = 0; i < this.GetComponent<BossController>().difficulty; i++) {
            GameObject child = (GameObject)Instantiate(enemy, this.transform.position, Quaternion.identity);
            child.transform.localScale = new Vector3(this.transform.localScale.x / (float)1.5, this.transform.localScale.y / (float)1.5, this.transform.localScale.z / (float)1.5);

            BossController childScript = child.GetComponent<BossController>();
            childScript.GetComponent<KingSlimeBehaviour>().currentLevel = currentLevel + 1;
            childScript.maxHealth = (int)(this.GetComponent<BossController>().maxHealth * threshold);
            childScript.currentHealth = (int)(this.GetComponent<BossController>().maxHealth * threshold);
        }

        Destroy(this.gameObject);
    }

    public void Spawn() {
        Vector3 spawnPoint = player.transform.position;
        spawnPoint.x += 15;
        spawnPoint.y += 15;
        Instantiate(this, spawnPoint, Quaternion.identity);
    }
}
