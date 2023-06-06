using UnityEngine;
using UnityEngine.UI; 

public class Parralax : MonoBehaviour
{
    [SerializeField] Vector3 camOffset=new Vector3(0,0,0); 
    Image bg;
    Camera cam; 
    void Start()
    {
        bg = GetComponent<Image>();
        cam = Camera.main; 
    }


    void FixedUpdate()
    {
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z)+camOffset; 
    }
}
