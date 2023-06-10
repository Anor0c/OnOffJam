using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAIChase : StateMachineBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float speed = 2;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2d = animator.gameObject.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMove>().gameObject;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2d.velocity = new Vector2(player.transform.position.x - animator.gameObject.transform.position.x, 0) * speed;
    }
}
