using UnityEngine.InputSystem; 
using UnityEngine;
using UnityEngine.Events;
using System.Collections; 

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpForce = 100f, jumpBuffer = 1f, noGravTime=1f;
    [SerializeField] bool isGrounded = false;
    bool justLanded; 
    Rigidbody2D rb2D;
    public UnityEvent OnJumpEvent, OnLanded; 
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
    }

    public void OnJump(InputAction.CallbackContext _ctx)
    {
        if (!isGrounded)
            return; 
        if (!_ctx.performed)
            return;
        OnJumpEvent.Invoke();
        StartCoroutine(JumpRoutine()); 
    }
   
    IEnumerator JumpRoutine()
    {
        rb2D.velocity += new Vector2(rb2D.velocity.x, jumpForce);
        rb2D.gravityScale = 0.05f; 
        yield return new WaitForSeconds(noGravTime);
        rb2D.gravityScale = 1f;
        yield return null; 
    }
    private void Update()
    {
        var _debugRay = Physics2D.Raycast(transform.position, new Vector2(0, -transform.up.y ), jumpBuffer);
        if (_debugRay.collider != null)
            isGrounded = true;
        else
            isGrounded = false; 
              //Debug.Log(_debugRay.collider);   
        Debug.DrawRay(transform.position, new Vector2(0, -transform.up.y * jumpBuffer), Color.green, 10000f);
    }
}
