using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    public KeyCode reloadKey = KeyCode.R; // Key to press for reloading the scene

    void Update()
    {
        if (Input.GetKeyDown(reloadKey))
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        // Get the currently active scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
