using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneChange : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0); 
    }
    public void ToGameplay()
    {
        SceneManager.LoadScene(1);
    }
    public void ToCredits()
    {
        SceneManager.LoadScene(2);
    }
    public void ToQuit()
    {
        Application.Quit(); 
    }
}
