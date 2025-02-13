using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this for scene management

public class Pausemenu : MonoBehaviour
{
    public CanvasGroup pauseMenuCanvasGroup;
    public Button resumeButton;
    public Button quitButton;

    bool isPaused = false;

    void Start()
    {
        // Attach button listeners
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);

        // Ensure pause menu starts hidden
        pauseMenuCanvasGroup.alpha = 0;
        pauseMenuCanvasGroup.interactable = false;
        pauseMenuCanvasGroup.blocksRaycasts = false;

        // Start the game in an unpaused state
        ResumeGame();
    }

    void Update()
    {
        // Check for pause input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Pause the game
        pauseMenuCanvasGroup.alpha = 1;
        pauseMenuCanvasGroup.interactable = true;
        pauseMenuCanvasGroup.blocksRaycasts = true;
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        Cursor.visible = true; // Show cursor
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Resume the game
        pauseMenuCanvasGroup.alpha = 0;
        pauseMenuCanvasGroup.interactable = false;
        pauseMenuCanvasGroup.blocksRaycasts = false;
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor
        Cursor.visible = false; // Hide cursor
    }

    public void ResumeGameButton()
    {
        ResumeGame();
    }

    public void QuitGame()
    {
        PlayerKey.keyCount = 0;
        // Load the main menu scene (assuming it is scene index 0)
        SceneManager.LoadScene(1);
    }
}
