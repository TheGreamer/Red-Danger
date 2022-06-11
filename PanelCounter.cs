using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelCounter : MonoBehaviour
{
    private float timer;
    private int state;
    private bool isDone;
    private Image panelImage;
    private Text panelText;

    private void Start()
    {
        timer = 10.0f;
        state = 1;
        isDone = false;
        panelImage = GetComponent<Image>();
        panelText = panelImage.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (timer <= 0.0f)
        {
            StartCoroutine(FadeImage());
            timer = 10.0f;
            state = 0;
        }
        else
        {
            if (state == 1)
            {
                timer -= Time.deltaTime;
            }
        }

        if (isDone)
        {
            Destroy(panelText);
        }
    }

    private IEnumerator FadeImage()
    {
        for (float i = 2; i >= 0; i -= Time.deltaTime)
        {
            panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, i);
            panelText.color = new Color(panelText.color.r, panelText.color.g, panelText.color.b, i);
            yield return null;
        }

        isDone = true;
    }
}