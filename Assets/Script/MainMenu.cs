using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);   
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has been quit");
    }
}
