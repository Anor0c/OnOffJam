using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : StateMachineBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float speed = 2;
    [SerializeField] float searchRadius; 

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2d = animator.gameObject.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMove>().gameObject;
        if ((player.transform.position - animator.gameObject.transform.position).magnitude > searchRadius)
        {
            player = null;
            animator.SetBool("isLit", true); 
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player)
            return; 
        rb2d.velocity = (player.transform.position - animator.gameObject.transform.position).normalized * speed;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2d.velocity = Vector2.zero;
    }
}
