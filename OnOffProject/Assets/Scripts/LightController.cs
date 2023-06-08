using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections; 
public class LightController : MonoBehaviour
{
    PlayerJump playerJump;
    new Light2D light;
    [SerializeField] float litInnerRadius = 4f, litOuterRadius = 6f, dimInnerRadius = 0.7f, dimOuterRadius = 1.5f;
    [SerializeField] float jumpApex = 10f; 
    [SerializeField] bool litRoutinePerformed;
    [SerializeField]float startPos, intJumpApex;
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
        float _currentLerpTime = transform.position.y - startPos;
        float _lerpRatio = _currentLerpTime / intJumpApex;
        light.pointLightInnerRadius = Mathf.Lerp(dimInnerRadius, litInnerRadius, _lerpRatio);
        light.pointLightOuterRadius = Mathf.Lerp(dimOuterRadius, litOuterRadius, _lerpRatio);
        Debug.Log("control");

    }
    private void Update()
    {
        if (playerJump.hasJumped)
        {
            LightRoutine();
        }
        
    }

    /*float _startDimTime = Time.time; 
    float _endDimTime = _startDimTime + dimLerpTime;
    while (Time.time < _endDimTime)
    {
        float _currentLerpTime = Time.time - _startDimTime;
        float _lerpRatio = _currentLerpTime / litLerpTime;
        light.pointLightInnerRadius = Mathf.Lerp(light.pointLightInnerRadius, dimInnerRadius, _lerpRatio);
        light.pointLightOuterRadius = Mathf.Lerp(light.pointLightOuterRadius, dimOuterRadius, _lerpRatio);
    }*/
    //litRoutinePerformed = false;


}
