using UnityEngine;
using UnityEngine.Events; 

public class ColEvent : MonoBehaviour
{
    [SerializeField] string activeTag = "Player"; 
    public UnityEvent OnTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == activeTag)
            OnTrigger.Invoke(); 
    }
}
