using UnityEngine;
using System.Collections;

public class SlamController : StateMachineBehaviour {

    public GameObject enemy, player, shockWave;
    public Vector3 playerPosition;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        enemy = GameObject.Find("FinalBoss");
        player = GameObject.Find("Tank");
        playerPosition = player.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		SoundAdapter.playFenceSound ();
		SoundAdapter.playTankHitSound ();
        GameObject shockWaveInstantiated = (GameObject)Instantiate(shockWave, enemy.transform.position, Quaternion.identity);
        shockWaveInstantiated.GetComponent<Slam>().target = playerPosition;
        shockWaveInstantiated.transform.LookAt(playerPosition);
        shockWaveInstantiated.transform.RotateAround(shockWaveInstantiated.transform.position, shockWaveInstantiated.transform.up, 180f);

        enemy.GetComponent<FinalBossBehaviour>().anim.SetBool("Slam", false);
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
