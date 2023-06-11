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
    public void ToWin()
    {
        SceneManager.LoadScene(3);
    }
    public void ToLose()
    {
        SceneManager.LoadScene(4); 
    }
    public void ToQuit()
    {
        Application.Quit(); 
    }
}
