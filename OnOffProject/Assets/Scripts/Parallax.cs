using UnityEngine;
using System; 

public class Parallax : MonoBehaviour
{
    [SerializeField]Transform[] bgArray; 
    [SerializeField]Transform bgFirst, bgLast;
    [SerializeField] float bgSize;
    [SerializeField] int currentIndex, lastIndex; 
    void Start()
    {
        bgFirst = bgArray[0];
        bgLast = bgArray[bgArray.Length-1]; 
    }

    void Update()
    {
        /*logique pour le remplacement de BG, ne marche pas ecore
         * if(lastIndex>bgArray.Length)
        {
            lastIndex = 0; 
        }
        foreach(Transform t in bgArray)
        {
            if (t.position.x > transform.position.x)
            {
                t.position = new Vector3(t.position.x + bgSize * bgArray.Length, t.position.y, t.position.z);
                currentIndex = Array.IndexOf(bgArray, t);
                lastIndex = Array.IndexOf(bgArray, t) - 1; 
            }
        }*/
    }
}
