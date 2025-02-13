using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingKeyBeach : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public CanvasGroup FailBackground;
    public AudioSource failaudio;
    private bool disableEscKey = false;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;
    bool m_playerfail;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && PlayerKey.keyCount > 8)
        {
            m_IsPlayerAtExit = true;
            PlayerKey.keyCount = 0;
            disableEscKey = true;  // Disable the ESC key
        }

        if (other.gameObject == player && PlayerKey.keyCount < 9)
        {
            m_playerfail = true;
            PlayerKey.keyCount = 0;
            disableEscKey = true;  // Disable the ESC key
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
        PlayerKey.keyCount = 0;
        disableEscKey = true;  // Disable the ESC key

    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
            Cursor.lockState = CursorLockMode.None; // Unlock cursor
            Cursor.visible = true; // Show cursor
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }

        else if (m_playerfail)
        {
            EndLevel(FailBackground, true, failaudio);
        }


        if (disableEscKey)
        {
            // Check if the ESC key is pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Disable ESC key functionality
                return;
            }

        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                ReloadScene();
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    void ReloadScene()
    {
        // Get the currently active scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}


