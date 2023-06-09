using UnityEngine.InputSystem; 
using UnityEngine;
using UnityEngine.Events; 

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed, maxSpeed = 10f;
    [SerializeField] Vector2 inputDir, momentum;
    Rigidbody2D rb2D;
    PlayerJump playerJump; 
    public UnityEvent<Vector2> onPressMovement;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerJump = GetComponent<PlayerJump>();
    }

    public void OnMove(InputAction.CallbackContext _ctx)
    {
        if (!_ctx.performed)
            inputDir = Vector2.zero;
        inputDir = _ctx.ReadValue<Vector2>();
        onPressMovement.Invoke(inputDir);  
    }
    public void CalculateMoment()
    {
        momentum = new Vector2(rb2D.velocity.x, 0); 
    }
    Vector2 PlayerDir()
    {
        if (playerJump.isGrounded)
        {
            var _playerDir = new Vector2(inputDir.x, 0);
            return _playerDir; 
        }
        else
        {
            var _playerDirAir = momentum.normalized*0.5f + new Vector2(inputDir.x, 0);
            return _playerDirAir; 
        }
    }
    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(PlayerDir().x * speed , rb2D.velocity.y); 
        if(rb2D.velocity.x>=maxSpeed)
        {
            rb2D.velocity = new Vector2(maxSpeed, rb2D.velocity.y);  
        }
        else if (rb2D.velocity.x <= -maxSpeed)
        {
            rb2D.velocity = new Vector2(-maxSpeed, rb2D.velocity.y); 
        }
    }
}
