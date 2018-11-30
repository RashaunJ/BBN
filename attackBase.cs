using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBase : StateMachineBehaviour {

    public float damage;
    public float hitboxRadius = 1f;
    public GameObject hitbox;
    public GameObject hurtbox;
    public GameObject player;
    public GameObject enemy;
    public GameObject enemyhitbox;
    private Transform playerPos;
    public float beamLength;
    public float raySkew;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        //Get player and enemy object
        player = GameObject.Find("Player");
        playerPos = player.transform;
       // hitbox = new GameObject();
        //Instantiate(hitbox, playerPos);
       // hitbox.gameObject.AddComponent<BoxCollider2D>();
        enemy = GameObject.Find("wizEnemy");

        hurtbox = GameObject.Find("hurtBox");
        //Ranged Beam length
        beamLength = 20f;
        raySkew = 0.1f;




        //hitbox = new BoxCollider2D();

        //Sets hitbox to slightly in front of player
        // hitbox.GetComponent<BoxCollider2D>().offset = new Vector2(playerPos.position.x + 1, playerPos.position.y);
        // hitbox.GetComponent<BoxCollider2D>().size = new Vector2(hitboxRadius+2, hitboxRadius);
        if (checkHit(hurtbox, enemy))
        {
            wizBehavior wiz = enemy.GetComponent<wizBehavior>();

            wiz.health -= 1;
            Debug.Log(wiz.health);
            
            Debug.Log("Enemy was hit");
        }

 
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Check if animation is still playing

        //Animation 1 Check
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
        {
            if (checkHit(hurtbox, enemy)==true)
            {
                
                Debug.Log("Enemy was hit");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Attack Extended");
                animator.SetBool("isAttacking", true);
                animator.SetBool("attackExtended", true);
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }

        }
        



    
        //Animation 2 Check
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing2"))
        {
            if (checkHit(hurtbox, enemy) == true)
            {
                Debug.Log("Enemy was hit during Extended");
            }

           if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Attack Extended to 3rd");
            animator.SetBool("isAttacking", true);
            animator.SetBool("attackExtended", true);
            animator.SetBool("attackExtend2", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("attackExtended", false);
        }

        
        }

        //Animation 3 Check
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing3"))
        {
            if (checkHit(hurtbox, enemy) == true)
            {
                Debug.Log("Enemy was hit during Extended 3");
            }

            animator.SetBool("isAttacking", false);
            animator.SetBool("attackExtended", false);
            animator.SetBool("attackExtend2", false);

        }

        //Range Attack Check
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("rangeAttack"))
        {
            RaycastHit2D hit = rangeCollide(player.transform);
            if (hit.collider && hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Hit with range attack");
                GameObject collidedObject = hit.collider.gameObject;
                collidedObject.GetComponent<wizBehavior>().health -= 1;
                

            }
            animator.SetBool("isRangeAttacking", false);
        }



    }

	//OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       // Destroy(hitbox);

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
    private bool checkHit(GameObject hitbox, GameObject enemy)
    {
        //Debug.Log("Hurtbox pos: " + hitbox.gameObject.GetComponent<BoxCollider2D>().transform.position);
        //Debug.Log("Enemy hitbox pos: " + enemy.gameObject.GetComponent<BoxCollider2D>().transform.position);
        if (hitbox.gameObject.GetComponent<BoxCollider2D>().bounds.Intersects(enemy.GetComponent<BoxCollider2D>().bounds  ))
        {
            
            Debug.Log("Enemy was hit");
            for(int i = 0; i < 5; i++)
            {
                enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                
            }
            return true;
        }
        return false;
    }

    private RaycastHit2D rangeCollide(Transform transform)
    {
        Vector2 cast = new Vector2(transform.position.x-raySkew , transform.position.y);



        Debug.DrawRay(cast, Vector2.right*beamLength, Color.yellow);

        return Physics2D.Raycast(cast, Vector2.right*beamLength);
    }
}

