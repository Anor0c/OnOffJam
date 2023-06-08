using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSliding : MonoBehaviour
{
    [Header("WallSlide")]
    const float wallCheckSize = 0.6f; 
    [SerializeField] float slidingSpeed=-2f;
    [SerializeField] bool isSliding = false, canSlide = false;
    const float bufferTime = 0.3f;
   
    [SerializeField] RaycastHit2D hit;
    ContactFilter2D contact; 
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
    public void DetectBufferSlide()
    {
        StartCoroutine(BufferRoutine()); 
    }
    IEnumerator BufferRoutine()
    {
        yield return new WaitForSeconds(bufferTime);
        canSlide = true; 
        yield return null; 
    }
    void Update()
    {
        if (!canSlide)
            return; 
        else if (sRenderer.flipX)
        {
            hit = Physics2D.Raycast(transform.position, -transform.right, wallCheckSize, 6);  //contact, hits, wallCheckSize, 6f); 
            Debug.DrawRay(transform.position, -transform.right * wallCheckSize, Color.yellow, 100000f);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, transform.right, wallCheckSize, 6);
            Debug.DrawRay(transform.position, transform.right * wallCheckSize, Color.yellow, 100000f);
        }
        Debug.Log(hit.collider);
        wallCheck = hit; 
        if (wallCheck)
            playerJump.canJump = true;
        else if (!playerJump.isGrounded)
            playerJump.canJump = false;
        else return;


        if (playerJump.isGrounded)
            canSlide = false;
        else return; 
    }
    private void FixedUpdate()
    {
        if (wallCheck)
        {
            isSliding = true; 
            rb2d.velocity = new Vector2(rb2d.velocity.x, slidingSpeed); 
        }
        else
        {
            isSliding = false; 
        }
    }
}
