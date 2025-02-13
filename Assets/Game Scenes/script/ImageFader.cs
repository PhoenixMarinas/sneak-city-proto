using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    public CanvasGroup canvasGroup;  // The CanvasGroup component controlling the image
    public float fadeDuration = 2f;  // Duration of the fade effect
    public float displayDuration = 2f; // Time the image is fully visible before fading out

    private float timer = 0f;

    void Start()
    {
        // Ensure the canvas group starts fully visible
        canvasGroup.alpha = 1f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > displayDuration)
        {
            float fadeOutTime = timer - displayDuration;
            canvasGroup.alpha = 1 - (fadeOutTime / fadeDuration);

            if (canvasGroup.alpha <= 0f)
            {
                canvasGroup.alpha = 0f;
                // Optionally, disable this script or the image to stop updating
                enabled = false;
                gameObject.SetActive(false);
            }
        }
    }
}
