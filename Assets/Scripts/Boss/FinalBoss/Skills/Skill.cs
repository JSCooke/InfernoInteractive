using UnityEngine;
using System.Collections;

public abstract class Skill : MonoBehaviour{

    public GameObject player;
    public GameObject enemy;
    public int damage;
    public ParticleSystem chargeParticles;
    public float chargeStartTime;
    public float chargeDuration = 1;
    public bool performSkill;

    public Skill() {}

    public Skill(GameObject player, GameObject enemy) {
        this.player = player;
        this.enemy = enemy;
    }

    public void activate(FinalBossBehaviour.Action action) {
        performSkill = true;

        if (performSkill == false) {
            switch (action) {
                case FinalBossBehaviour.Action.ILLUSION:
                    illusion();
                    break;
                case FinalBossBehaviour.Action.SHIELD:
                    shield();
                    break;
                case FinalBossBehaviour.Action.LASER:
                    laser();
                    break;
                case FinalBossBehaviour.Action.SNARE:
                    snare();
                    break;

            }
        } 

        //Finished charging and started skill
        if (Time.fixedTime > (chargeStartTime + chargeDuration)) {
            performSkill = true;
        }
        
        
    }

    void illusion() {
        //print("elluding");
    }

    void shield() {

    }

    void laser() {

    }

    void snare() {

    }
}
