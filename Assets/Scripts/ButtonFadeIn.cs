using UnityEngine;
using UnityEngine.UI;

public class ButtonFadeIn : MonoBehaviour
{
    public Button button;
    public float fadeDuration = 1f;
    public float fadeDelay = 0.5f;

    private CanvasGroup canvasGroup;
    private float targetAlpha = 0f;
    private float currentAlpha = 0f;
    private bool isFading = false;

    private void Start()
    {
        canvasGroup = button.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;
        button.onClick.AddListener(OnButtonClick);
    }

    private void Update()
    {
        if (isFading)
        {
            currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime / fadeDuration);
            canvasGroup.alpha = currentAlpha;

            if (Mathf.Abs(currentAlpha - targetAlpha) < 0.01f)
            {
                canvasGroup.alpha = targetAlpha;
                isFading = false;
            }
        }
    }

    private void OnButtonClick()
    {
        if (!isFading)
        {
            targetAlpha = 0f;
            currentAlpha = 1f;
            isFading = true;
        }
    }
}
