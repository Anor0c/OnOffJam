using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdle : StateMachineBehaviour
{
    [SerializeField] float idleTimer = 0.5f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        idleTimer = 0.5f; 
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        idleTimer -= Time.deltaTime;
        animator.SetFloat("IdleTimer", idleTimer); 
    }
}
