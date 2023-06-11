using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColider : MonoBehaviour
{
    [SerializeField] float maxSize = 5;
    public CircleCollider2D col; 
    void Start()
    {
        col = GetComponentInParent<CircleCollider2D>(); 
    }

public void ColiderSizer(float _lightSize)
    {
        if (_lightSize <= 0.25f)
        {
            col.enabled = false; 
        }
        else if (_lightSize<=1f)
        {
            col.enabled = true;
            col.radius = _lightSize * maxSize; 
        }
        else
        {
            col.enabled = true;
            col.radius = maxSize; 
        }
    }
}
