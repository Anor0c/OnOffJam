using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 camOffset = new Vector3(0, 0, 0);
    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z) + camOffset;
    }
}
