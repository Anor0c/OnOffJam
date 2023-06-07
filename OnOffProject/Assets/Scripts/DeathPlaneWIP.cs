using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneWIP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = Vector3.zero; 
    }
}
