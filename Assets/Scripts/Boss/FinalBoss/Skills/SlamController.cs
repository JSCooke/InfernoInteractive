using UnityEngine;
using System.Collections;

public class SlamController : StateMachineBehaviour {

    public GameObject shockWave;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        GameObject player = enemy.GetComponent<FinalBossBehaviour>().player;

        GameObject shockWaveInstantiated = (GameObject)Instantiate(shockWave, enemy.transform.position, Quaternion.identity);

        ParticleSystem shockwaveEffect = shockWaveInstantiated.GetComponentsInChildren<ParticleSystem>()[0];
        Vector3 relativePos = player.transform.position - shockWaveInstantiated.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        shockwaveEffect.startRotation = Mathf.Deg2Rad * rotation.eulerAngles.y;
        shockwaveEffect.startLifetime = 1;
        shockwaveEffect.startSize = 30;
        shockwaveEffect.Play();

        shockWaveInstantiated.transform.LookAt(player.transform.position, shockWaveInstantiated.transform.up);
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
