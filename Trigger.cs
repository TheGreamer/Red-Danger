using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    private AudioSource music;
    private float volumeTimer;
    private int soundController = 0;

    [HideInInspector] public static bool levelFailed;

    [Header("Screens")]
    public Image successMessage;
    public Image failMessage;
    public Image pauseScreen;

    [Header("UI Buttons")]
    public GameObject levelSelectButton;
    public GameObject restartButton;
    public GameObject pauseButton;
    public GameObject helpButton;

    [Header("Sound")]
    public AudioSource levelFailedSound;

    private void Start()
    {
        levelFailed = false;
        volumeTimer = levelFailedSound.clip.length;
        music = GameObject.Find("Music Management").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string objectTag = other.gameObject.tag;

        if (objectTag.Contains("Green"))
        {
            if (!failMessage.IsDestroyed())
            {
                Destroy(successMessage);
                Destroy(levelSelectButton);
                Destroy(restartButton);
                Destroy(pauseButton);
                Destroy(GameObject.Find("Triggers"));
                try { Destroy(helpButton); } catch { }
                Destroy(GameObject.Find("Loading Circle"));
                failMessage.gameObject.SetActive(true);

                levelFailed = true;
                volumeTimer -= Time.deltaTime;
                music.volume = volumeTimer > 0.0f ? 0.1f : 1.0f;

                if (soundController == 0)
                {
                    if (SoundToggle.isToggled)
                    {
                        levelFailedSound.Play();
                    }
                    soundController = 1;
                }

                Destroy(levelFailedSound, 3.001f);
            }
        }

        Destroy(other.gameObject);
    }
}