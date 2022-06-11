using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    [HideInInspector] public static bool isToggled = true;
    private AudioSource musicSource;

    [Header("Image Button")]
    public Image musicButton;

    [Header("Colors")]
    public Color pausedColor;
    public Color unPausedColor;

    public void ToggleMusic()
    {
        musicSource = GameObject.Find("Music Management").GetComponent<AudioSource>();

        if (isToggled)
        {
            musicSource.Pause();
            isToggled = false;
            musicButton.color = pausedColor;
            PlayerPrefs.SetInt("Paused", 1);
        }
        else
        {
            musicSource.UnPause();
            isToggled = true;
            musicButton.color = unPausedColor;
            PlayerPrefs.SetInt("Paused", 0);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Paused") == 0)
        {
            isToggled = true;
            musicButton.color = unPausedColor;
        }
        else
        {
            isToggled = false;
            musicButton.color = pausedColor;
        }
    }
}