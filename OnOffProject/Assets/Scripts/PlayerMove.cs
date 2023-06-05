using UnityEngine.InputSystem; 
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 inputDir, playerDir;
    Rigidbody2D rb2D; 

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
    }

    public void OnMove(InputAction.CallbackContext _ctx)
    {
        if (!_ctx.performed)
            inputDir = Vector2.zero;
        inputDir = _ctx.ReadValue<Vector2>(); 
    }
    private void Update()
    {
        playerDir = new Vector2(inputDir.x, 0); 
    }
    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(playerDir.x * speed , rb2D.velocity.y); 
    }
}
