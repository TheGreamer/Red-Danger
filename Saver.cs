using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Saver : TransitionManagement
{
    private Image loadingScreen;

    private void Start()
    {
        loadingScreen = GameObject.Find("Loading Screen").GetComponent<Image>();
        loadingScreen.enabled = true;
        StartCoroutine(FadeIn(0.25f, loadingScreen));
    }

    public void NextLevel()
    {
        StartCoroutine(FadeOut(0.25f, loadingScreen, SceneManager.GetActiveScene().buildIndex + 1));
    }
}