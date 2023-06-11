using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelAnimatorAI : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        animator.SetBool("isLit", true);
        Debug.Log("lit");
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        animator.SetBool("isLit", false);
    }
}
