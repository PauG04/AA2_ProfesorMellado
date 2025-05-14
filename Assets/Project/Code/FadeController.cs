using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private float fadeTimer = 0f;
    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private string sceneToLoad = "";

    private void Start()
    {
        StartFadeOut();
    }

    private void Update()
    {
        if (isFadingIn)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);
            SetAlpha(alpha);

            if (alpha >= 1f)
            {
                isFadingIn = false;
                if (!string.IsNullOrWhiteSpace(sceneToLoad))
                {
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        }
        else if (isFadingOut)
        {
            fadeTimer += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(fadeTimer / fadeDuration);
            SetAlpha(alpha);

            if (alpha <= 0f)
            {
                isFadingOut = false;
            }
        }
    }

    private void SetAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }

    public void StartFadeIn(string sceneName = "")
    {
        fadeTimer = 0f;
        isFadingIn = true;
        isFadingOut = false;
        sceneToLoad = sceneName;
    }

    public void StartFadeOut()
    {
        fadeTimer = 0f;
        isFadingOut = true;
        isFadingIn = false;
        sceneToLoad = "";
    }
}
