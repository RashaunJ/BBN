using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBase : StateMachineBehaviour {
    GameObject obj;
    int health;
    int trackHealth;
    wizBehavior wiz;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        obj = GameObject.Find("wizEnemy");
        wiz = obj.GetComponent<wizBehavior>();
        health = wiz.health;
        trackHealth = wiz.trackHealth;
        //Debug.Log("anim health: " + health);
        //Debug.Log("track health: " + trackHealth);

        //On state enter if currently in damage animation, go back to idle
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("flash"))
        {
            animator.SetBool("damaged", false);
        }
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        //On state update if currently in damage animation, go back to idle
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("flash"))
        {
            animator.SetBool("damaged", false);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (wiz.health < wiz.trackHealth)
            {
                Debug.Log("anim health: " + health);
                Debug.Log("track health: " + trackHealth);
                animator.SetBool("damaged", true);
                wiz.trackHealth = wiz.health;
            }
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
