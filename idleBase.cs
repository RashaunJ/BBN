using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBase : StateMachineBehaviour {

    GameObject player;
    

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //   if (Input.GetKeyDown(KeyCode.Space))
        //   {
        //       Debug.Log("Button Pressed");
        //      animator.SetBool("isAttacking", true);
        //  }

        player = GameObject.Find("Player");
        
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Button Pressed");
            Debug.Log(animator.GetBool("isAttacking"));
            animator.SetBool("isAttacking", true);
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z Button Pressed");
         
            animator.SetBool("isRangeAttacking", true);
        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
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
