using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinalBossBehaviour : Spawnable {

    public GameObject player;
    private Vector3 playerPosition;

    private Rigidbody rb;
    private float currentHealth, maxHealth;

    //Different types of skills
    public enum Action {
        STATIONARY,
        SHIELD,
        METEOR,
        SNARE,
        SLAM
    };

    public Animator anim;

    public bool newAction;
    private Queue lastSkillsUsed = new Queue();

    // Use this for initialization
    void Start() {
        
        maxHealth = this.GetComponent<BossController>().maxHealth;
        currentHealth = maxHealth;

        if (player == null) {
            player = UnityEngine.GameObject.FindGameObjectsWithTag("Player")[0];
        }

        anim = this.gameObject.GetComponent<Animator>();
		newAction = false;
    }

    // Update is called once per frame
    void Update() {

        if (Time.timeScale == 0) {
            return;
        }

        currentHealth = this.GetComponent<BossController>().currentHealth;

        if (this.GetComponent<BossController>().dead) {
            Die();
        }
        else {

			if (anim.GetBool("Ready")){
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - this.transform.position), this.GetComponent<BossController>().rotationSpeed * Time.deltaTime);
				fightPlayer();
			}
            
        }

    }

	void resetAnimators (){
		anim.SetBool ("Slam", false);
		anim.SetBool ("Meteor", false);
		anim.SetBool ("Shield", false);
		anim.SetBool ("Snare", false);
		anim.SetBool ("Stationary", false);
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

			if (randSkill <= 30) {  //Slam
                //print("Slam");
                updateQueue(Action.SLAM);
                anim.SetBool("Slam", true);
				SoundAdapter.playFrogSound ();
				SoundAdapter.playHoverSound ();

			} else if (randSkill <= 45 && currentHealth <= (maxHealth * 0.25) && !lastSkillsUsed.Contains(Action.METEOR)) {     //Meteor
                //print("Meteor");
                updateQueue(Action.METEOR);
                anim.SetBool("Meteor", true);
				SoundAdapter.playFrogSound ();
				SoundAdapter.playHoverSound ();

			} else if (randSkill <= 60 && currentHealth <= (maxHealth * 0.50) && !lastSkillsUsed.Contains(Action.SHIELD)) {     //Shield
                //print("Shield");
                updateQueue(Action.SHIELD);
                anim.SetBool("Shield", true);
				SoundAdapter.playFrogSound ();
				SoundAdapter.playHoverSound ();

			} else if (randSkill <= 75 && currentHealth <= (maxHealth * 0.75) && !lastSkillsUsed.Contains(Action.SNARE)) {     //Snare
                //print("Snare");
                updateQueue(Action.SNARE);
                anim.SetBool("Snare", true);
				SoundAdapter.playFrogSound ();
				SoundAdapter.playHoverSound ();

            } else {     //Stationary
				//anim.SetBool("Stationary", true);
				updateQueue(Action.STATIONARY);
				anim.SetBool("Stationary", true);
				SoundAdapter.playFrogSound ();
				SoundAdapter.playHoverSound ();
            }

        }

    }

    void Die() {
        anim.SetBool("Die", true);
    }

}