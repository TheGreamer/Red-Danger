using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManagement : MonoBehaviour
{
    public IEnumerator FadeIn(float speed, Image image)
    {
        yield return StartCoroutine(Fade(image, speed, Color.black, Color.clear));
    }

    public IEnumerator FadeOut(float speed, Image image, int buildIndex)
    {
        Time.timeScale = 1.0f;
        yield return StartCoroutine(Fade(image, speed, Color.clear, Color.black));
        SceneManager.LoadScene(buildIndex);
    }

    private IEnumerator Fade(Image image, float duration, Color startColor, Color endColor)
    {
        float start = Time.time;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed = Time.time - start;
            float normalisedTime = Mathf.Clamp(elapsed / duration, 0, 1);
            image.color = Color.Lerp(startColor, endColor, normalisedTime);
            yield return null;
        }
    }
}