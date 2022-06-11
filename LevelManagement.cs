using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagement : TransitionManagement
{
    private Image loadingScreen;

    private void Start()
    {
        loadingScreen = GameObject.Find("Loading Screen").GetComponent<Image>();
        loadingScreen.enabled = true;
        StartCoroutine(FadeIn(0.25f, loadingScreen));
    }

    public void RestartLevel()
    {
        StartCoroutine(FadeOut(0.25f, loadingScreen, SceneManager.GetActiveScene().buildIndex));
    }

    public void LevelSelect()
    {
        StartCoroutine(FadeOut(0.25f, loadingScreen, SceneManager.sceneCountInBuildSettings - 1));
    }

    public void MainMenu()
    {
        StartCoroutine(FadeOut(0.25f, loadingScreen, SceneManager.sceneCountInBuildSettings - SceneManager.sceneCountInBuildSettings));
    }

    public void QuitGame()
    {
        string[] keys = { "Paused", "SoundsPaused" };

        foreach (string key in keys)
        {
            PlayerPrefs.DeleteKey(key);
        }

        Application.Quit();

        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif
    }
}