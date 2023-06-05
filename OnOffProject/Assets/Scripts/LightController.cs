using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections; 
public class LightController : MonoBehaviour
{
    new Light2D light;
    [SerializeField] float litInnerRadius = 4f, litOuterRadius = 6f, dimInnerRadius = 0.7f, dimOuterRadius = 1.5f;
    [SerializeField] float litTimer = 1.5f; 
    void Start()
    {
        light = GetComponent<Light2D>();  
    }

    public void IncreaseLight()
    {
        StartCoroutine(LightRoutine());
    }
    IEnumerator LightRoutine()
    {
        light.pointLightInnerRadius = Mathf.Lerp(light.pointLightInnerRadius, litInnerRadius, Time.time );
        light.pointLightOuterRadius = Mathf.Lerp(light.pointLightOuterRadius, litOuterRadius, Time.time );
        yield return new WaitForSeconds(litTimer);
        light.pointLightInnerRadius = Mathf.Lerp(light.pointLightInnerRadius, dimInnerRadius, Time.time );
        light.pointLightOuterRadius = Mathf.Lerp(light.pointLightOuterRadius, dimOuterRadius, Time.time );
        yield return null; 
    }
}
