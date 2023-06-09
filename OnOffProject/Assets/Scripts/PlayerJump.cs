using UnityEngine.InputSystem; 
using UnityEngine;
using UnityEngine.Events;
using System.Collections; 

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpForce = 100f, jumpBuffer = 1f, noGravTime=1f;
    public bool isGrounded = false, canJump = false; 
    float defaultGravityScale;
    public bool hasJumped = false;
    bool isAscend; 
    Rigidbody2D rb2D;
    RaycastHit2D hit; 
    public UnityEvent OnJumpEvent; 
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        defaultGravityScale = rb2D.gravityScale; 
    }

    public void OnJump(InputAction.CallbackContext _ctx)
    {
        if (!canJump)
            return; 
        if (!_ctx.performed)
            return;
        isAscend = true; 
        hasJumped = true; 
        OnJumpEvent.Invoke();
        StartCoroutine(JumpRoutine()); 
    }
   
    IEnumerator JumpRoutine()
    {
        rb2D.velocity += new Vector2(rb2D.velocity.x, jumpForce);
        rb2D.gravityScale = 0.05f; 
        yield return new WaitForSeconds(noGravTime);
        rb2D.gravityScale = defaultGravityScale;
        isAscend = false; 
        yield return null; 
    }
    private void Update()
    {
        if (!isAscend)
        {
        hit = Physics2D.Raycast(transform.position, new Vector2(0, -transform.up.y ), jumpBuffer);
        Debug.DrawRay(transform.position, new Vector2(0, -transform.up.y * jumpBuffer), Color.green, 10000f);

        }

        if (hit.collider != null)
            isGrounded = true;
        else
            isGrounded = false;
        if (isGrounded)
        {
            canJump = true;
            hasJumped = false;
        }
              //Debug.Log(_debugRay.collider);   
    }
}
