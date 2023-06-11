using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events; 
using System.Collections; 
public class LightController : MonoBehaviour
{
    PlayerJump playerJump;
    new Light2D light;
    [SerializeField] float litInnerRadius = 4f, litOuterRadius = 6f, dimInnerRadius = 0.7f, dimOuterRadius = 1.5f;
    [SerializeField] float jumpApex = 10; 
    [SerializeField] bool litRoutinePerformed;
    float startPos, intJumpApex, currentLerpTime, lerpRatio;
    public UnityEvent<float> onLightChange; 
    void Start()
    {
        light = GetComponent<Light2D>();
        playerJump = GetComponentInParent<PlayerJump>(); 
    }


    public void LightControl()
    {
        //litRoutinePerformed = true; 
        startPos = transform.position.y;
        intJumpApex = startPos + jumpApex;
        LightRoutine();

    }
    void LightRoutine()
    {
        currentLerpTime = transform.position.y - startPos;
        lerpRatio = currentLerpTime / intJumpApex;
        light.pointLightInnerRadius = Mathf.Lerp(dimInnerRadius, litInnerRadius, lerpRatio);
        light.pointLightOuterRadius = Mathf.Lerp(dimOuterRadius, litOuterRadius, lerpRatio);
        onLightChange.Invoke(lerpRatio); 
        Debug.Log("control");

    }
    private void Update()
    {
        if (!playerJump.isGrounded)
        {
            LightRoutine();
        }
        else
        {
            light.pointLightInnerRadius = dimInnerRadius;
            light.pointLightOuterRadius = dimOuterRadius; 
        }
        
    }
}
