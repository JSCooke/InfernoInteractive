using UnityEngine;
using System.Collections;

public class KingSlimeBehaviour : Spawnable {

    public UnityEngine.GameObject enemy;
    public UnityEngine.GameObject player = null;

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
    public int attackRate = 10;

    public GameObject boundary;

    // Use this for initialization
    void Start() {
        chargeParticles.enableEmission = false;
        rb = GetComponent<Rigidbody>();

        maxHealth = this.GetComponent<BossController>().maxHealth;
        currentHealth = maxHealth;

        this.GetComponent<BossController>().totalHealth = 100 + (200 * (this.GetComponent<BossController>().difficulty - 1));

		print (player);
        if (player == null) {
			player = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
        }

		print (UnityEngine.GameObject.FindGameObjectsWithTag("Player"));

    }

    // Update is called once per frame
    void Update() {

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (Time.timeScale == 0) {
            return;
        }

        currentHealth = this.GetComponent<BossController>().currentHealth;

        if (currentLevel < maxLevel && currentHealth <= 0) {
            duplicate();
        }

        if (this.GetComponent<BossController>().dead) {
            StartCoroutine(Die());
        } else {
            fightPlayer();
        }
        

    }

    void fightPlayer() {

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
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime * 6);

        if (transform.position == playerPosition) {
            dashing = false;
            finding = true;
        }
    }

    void roam() {
        //print(randomPosition);
        transform.position = Vector3.MoveTowards(transform.position, randomPosition, this.GetComponent<BossController>().bossSpeed * Time.deltaTime);

        float chance = Random.Range(0,100);

        //Once finished walking, decide whether to attack or roam again. Rebalance boss here if too hard
        if (transform.position == randomPosition) {

            //Rebalance attack rate here
            if (chance <= (100 - attackRate)) { //Roam again
                randomPosition = Random.insideUnitCircle * 10;

                randomPosition.x += transform.position.x;
                randomPosition.z = randomPosition.y;
                randomPosition.z += transform.position.z;
                randomPosition.y = 0;
            } else { //Attack
                roaming = false;
                charging = true;
                chargeStartTime = Time.fixedTime;
            }
        }

    }

    void findRandomPosition() {
        
        randomPosition = Random.insideUnitCircle * 10;
        
        randomPosition.x += transform.position.x;
        randomPosition.z = randomPosition.y;
        randomPosition.z += transform.position.z;
        randomPosition.y = 0;

        finding = false;
        roaming = true;
    }

    void OnCollisionEnter(Collision collision) {

        string collidedTag = collision.gameObject.tag;
        if (collidedTag == "Player" || collidedTag == "Enemy") {
            dashing = false;
            finding = true;
        }
        
    }

    void OnTriggerStay(Collider collider) {
        string collidedTag = collider.gameObject.tag;
        if (collidedTag == "Player" || collidedTag == "Enemy") {
            dashing = false;
            finding = true;
        }

    }

    void duplicate() {

        float radius = 2f;

        for (int i = 0; i < this.GetComponent<BossController>().difficulty; i++) {

            //Referenced from http://answers.unity3d.com/questions/1068513/place-8-objects-around-a-target-gameobject.html
            float angle = i * Mathf.PI * 2f / this.GetComponent<BossController>().difficulty;
            Vector3 newPos = new Vector3(this.transform.position.x + Mathf.Cos(angle) * radius, 0, this.transform.position.z + Mathf.Sin(angle) * radius);

            GameObject child = (GameObject)Instantiate(enemy, newPos, Quaternion.identity);
            child.transform.localScale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y / 2, this.transform.localScale.z / 2);

            BossController childScript = child.GetComponent<BossController>();
            childScript.GetComponent<KingSlimeBehaviour>().currentLevel = currentLevel + 1;
            childScript.maxHealth = (int)(maxHealth * threshold);
            childScript.currentHealth = childScript.maxHealth;

        }

        StartCoroutine(Die());
        
    }

    IEnumerator Die() {
		print ("dead");
        //Only animate death for smallest slimes
        if (this.GetComponent<KingSlimeBehaviour>().currentLevel == maxLevel) {
            Quaternion targetRotation = Quaternion.Euler(new Vector3(90, 45, 0));
            rb.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 2.5F);

            //Wait for 1 second animation to finish
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }


    }

    public override void Spawn() {

		Start ();
        Vector3 spawnPoint = player.transform.position;
        spawnPoint.z += 20;
        spawnPoint.y += 2;
        Instantiate(this, spawnPoint, Quaternion.identity);
        Instantiate(boundary,new Vector3(0,0,395),Quaternion.identity);
		UIAdapter.setBossUI (true);
    }

}
