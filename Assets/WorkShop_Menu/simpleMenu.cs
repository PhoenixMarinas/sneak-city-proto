using UnityEngine;
using UnityEngine.SceneManagement;

public class simpleMenu : MonoBehaviour
{
    // This method will be called when the Play button is clicked
    public void PlayGame()
    {
        // Replace 1 with the build index of the scene you want to load
        SceneManager.LoadScene(2);
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayGame3()
    {
        SceneManager.LoadScene(6);
    }

    public void PlayGame4()
    {
        SceneManager.LoadScene(8);
    }

    public void PlayGame5()
    {
        SceneManager.LoadScene(10);
    }


    // This method will be called when the Quit button is clicked
    public void QuitGame()
    {
        // Quits the application
        Application.Quit();

        // If we are running in the Unity editor, stop playing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
