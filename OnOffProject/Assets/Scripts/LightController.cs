using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections; 
public class LightController : MonoBehaviour
{
    new Light2D light;
    [SerializeField] float litInnerRadius = 4f, litOuterRadius = 6f, dimInnerRadius = 0.7f, dimOuterRadius = 1.5f;
    [SerializeField] float litPause = 1.5f, litLerpTime = 0.7f, dimLerpTime = 0.3f;
    [SerializeField] bool litRoutinePerformed; 
    void Start()
    {
        light = GetComponent<Light2D>();  
    }
    /*public void DimLight()
    {
        if (dimRoutinePerformed)
            return;
        else
        {
            StartCoroutine(DimRoutine());
            Debug.Log("dimLight");
        }

    }*/
    public void IncreaseLight()
    {
        if (litRoutinePerformed)
            return; 
        StartCoroutine(LightRoutine());
    }
    IEnumerator LightRoutine()
    {
        //litRoutinePerformed = true; 
        float _startTime = Time.time;
        float _endTime = _startTime + litLerpTime;
        while (Time.time < _endTime)
        {
            float _currentLerpTime = Time.time - _startTime;
            float _lerpRatio = _currentLerpTime / litLerpTime;
            light.pointLightInnerRadius = Mathf.Lerp(light.pointLightInnerRadius, litInnerRadius, _lerpRatio);
            light.pointLightOuterRadius = Mathf.Lerp(light.pointLightOuterRadius, litOuterRadius, _lerpRatio);
            yield return null; 
        }
        yield return new WaitForSeconds(litPause);
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
        yield return null; 
    }
}
