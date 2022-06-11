using UnityEngine;
using UnityEngine.UI;

public class MenuManagement : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject levelSelectButton;
    public GameObject restartButton;
    public GameObject pauseButton;
    public GameObject helpButton;
    public GameObject pauseScreen;

    [HideInInspector] public static bool isPaused;

    [Header("Time Scale Options")]
    [Range(0f, 1f)] public float pauseTimeScale;
    [Range(0f, 1f)] public float resumeTimeScale;

    [Header("Sound")]
    public AudioSource sound;

    [Header("Colors")]
    public Color pauseColor;
    public Color resumeColor;

    private AudioSource audioSource;
    private Image canvasImage;

    private void Start()
    {
        isPaused = false;
        audioSource = GameObject.Find("Music Management").GetComponent<AudioSource>();
        canvasImage = GameObject.Find("Canvas").GetComponent<Image>();
        canvasImage.enabled = false;
        canvasImage.color = resumeColor;
    }

    public void Pause()
    {
        levelSelectButton.SetActive(false);
        restartButton.SetActive(false);
        pauseButton.SetActive(false);
        try { helpButton.SetActive(false); } catch { }
        pauseScreen.SetActive(true);
        isPaused = true;
        audioSource.volume = 0.1f;
        if (SoundToggle.isToggled)
        {
            sound.Play();
        }
        canvasImage.enabled = true;
        canvasImage.color = pauseColor;
        Time.timeScale = pauseTimeScale;
    }

    public void Resume()
    {
        levelSelectButton.SetActive(true);
        restartButton.SetActive(true);
        pauseButton.SetActive(true);
        try { helpButton.SetActive(true); } catch { }
        pauseScreen.SetActive(false);
        isPaused = false;
        audioSource.volume = 1.0f;
        if (SoundToggle.isToggled)
        {
            sound.Play();
        }
        canvasImage.enabled = false;
        canvasImage.color = resumeColor;
        Time.timeScale = resumeTimeScale;
    }
}