using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [HideInInspector] public static bool isToggled = true;

    [Header("Image Button")]
    public Image soundButton;

    [Header("Colors")]
    public Color pausedColor;
    public Color unPausedColor;

    public void ToggleSound()
    {
        if (isToggled)
        {
            isToggled = false;
            soundButton.color = pausedColor;
            PlayerPrefs.SetInt("SoundsPaused", 1);
        }
        else
        {
            isToggled = true;
            soundButton.color = unPausedColor;
            PlayerPrefs.SetInt("SoundsPaused", 0);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("SoundsPaused") == 0)
        {
            isToggled = true;
            soundButton.color = unPausedColor;
        }
        else
        {
            isToggled = false;
            soundButton.color = pausedColor;
        }
    }
}