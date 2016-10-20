using UnityEngine;
using System.Collections;

public abstract class SkillController : MonoBehaviour{

    public GameObject player;
    public GameObject enemy;
    public int damage;
    public ParticleSystem chargeParticles;
    public bool performSkill;

    public FinalBossBehaviour.Action action;

    public SkillController() {}

    public SkillController(GameObject player, GameObject enemy) {
        this.player = player;
        this.enemy = enemy;
    }

}
