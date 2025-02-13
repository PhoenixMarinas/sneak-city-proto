using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneButton : MonoBehaviour
{
    // This method will be called when the Play button is clicked
    public void PlayGame()
    {
        // Replace 1 with the build index of the scene you want to load
        Scene currentScene = SceneManager.GetActiveScene();

        // Calculate the build index of the next scene
        int nextSceneIndex = currentScene.buildIndex + 1;

        // Check if the next scene index is within the range of scenes defined in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
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
