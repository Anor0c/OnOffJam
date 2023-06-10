using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBlidBehaviour : StateMachineBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float speed = 2, timer = 1.5f;
    Vector2 target;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2d = animator.gameObject.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMove>().gameObject;
        target = player.transform.position;

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;
        animator.SetFloat("BlindTimer", timer);
        rb2d.velocity = new Vector2(target.x - animator.gameObject.transform.position.x, 0) * speed;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 1.5f;
        animator.SetFloat("BlindTimer", timer);
        rb2d.velocity = Vector2.zero;
    }
}
