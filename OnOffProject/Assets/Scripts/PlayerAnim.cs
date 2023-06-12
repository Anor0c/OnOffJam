using UnityEngine;
using UnityEngine.Events; 

public class PlayerAnim : MonoBehaviour
{
    SpriteRenderer sRenderer; 
    void Start()
    {
        sRenderer = GetComponentInChildren<SpriteRenderer>(); 
    }
    public void FlipOnInput(Vector2 _inputDir)
    {
        if (_inputDir.x < 0)
            sRenderer.flipX = true;

        else if (_inputDir.x > 0)
            sRenderer.flipX = false;
        else return; 
    }
}
