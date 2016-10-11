using UnityEngine;
using System.Collections;

public abstract class Skill : MonoBehaviour{

    public GameObject player;
    public GameObject enemy;
    public int damage;
    public ParticleSystem chargeParticles;
    public float chargeStartTime;
    public float chargeDuration = 3;
    public bool performSkill;

    public Skill() {}

    public Skill(GameObject player, GameObject enemy) {
        this.player = player;
        this.enemy = enemy;
    }

    public void activate(FinalBossBehaviour.Action action) {

        if (performSkill == false) {
            chargeParticles.enableEmission = true;
            performSkill = true;
        } 

        //Finished charging and started skill
        //if (Time.fixedTime > (chargeStartTime + chargeDuration)) {
        //    performSkill = true;
        //    chargeParticles.enableEmission = false;
        //}
        
        
    }

    void illusion() {

    }

    void shield() {

    }

    void laser() {

    }

    void snare() {

    }
}
