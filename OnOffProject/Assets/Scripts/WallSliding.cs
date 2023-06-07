using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSliding : MonoBehaviour
{
    [Header("WallSlide")]
    const float wallCheckSize = 0.6f; 
    [SerializeField] float slidingSpeed=-2f;
    bool isSliding = false;

    [Header("WallJump")]
    [SerializeField] Vector2 wallJumpDirection = new Vector2(0, 0);
    [SerializeField] bool wallCheck;
    [SerializeField] float wallJumpCounter;  

    Rigidbody2D rb2d;
    SpriteRenderer sRenderer;
    PlayerJump playerJump; 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sRenderer = GetComponentInChildren<SpriteRenderer>();
        playerJump = GetComponent<PlayerJump>(); 
    }


    void Update()
    {
        if (playerJump.isGrounded)
            return;
        else if (sRenderer.flipX)
        {
            wallCheck = Physics2D.Raycast(transform.position, -transform.right, wallCheckSize);
            Debug.DrawRay(transform.position, -transform.right * wallCheckSize, Color.yellow, 100000f);
        }
        else
        {
            wallCheck = Physics2D.Raycast(transform.position, transform.right, wallCheckSize);
            Debug.DrawRay(transform.position, transform.right * wallCheckSize, Color.yellow, 100000f); 
        }
        if (wallCheck)
            playerJump.canJump = true;
        else if (!playerJump.isGrounded)
            playerJump.canJump = false; 

    }
    private void FixedUpdate()
    {
        if (wallCheck)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, slidingSpeed); 
        }
    }
}
