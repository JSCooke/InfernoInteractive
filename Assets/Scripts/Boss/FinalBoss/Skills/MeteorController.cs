using UnityEngine;
using System.Collections;

public class MeteorController : StateMachineBehaviour {

    public GameObject player, enemy, meteor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { 

        GameObject player = enemy.GetComponent<FinalBossBehaviour>().player;
        float radius = 6f;

        //this.GetComponent<BossController>().difficulty
        for (int i = 0; i < 2; i++) {

            //Referenced from http://answers.unity3d.com/questions/1068513/place-8-objects-around-a-target-gameobject.html
            //float angle = i * Mathf.PI * 2f / this.GetComponent<BossController>().difficulty;
            float angle = i * Mathf.PI * 2f / 2;
            Vector3 newPos = new Vector3(player.transform.position.x + Mathf.Cos(angle) * radius, 0, player.transform.position.z + Mathf.Sin(angle) * radius);
            newPos.y += 2;

            GameObject child = (GameObject)Instantiate(meteor, newPos, Quaternion.identity);
        }
        enemy.GetComponent<FinalBossBehaviour>().anim.SetBool("Meteor", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
