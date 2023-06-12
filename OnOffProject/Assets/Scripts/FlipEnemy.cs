using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    SpriteRenderer sRenderer;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb2d.velocity.x < 0)
            sRenderer.flipX = true;
        else
            sRenderer.flipX = false;
    }
}
