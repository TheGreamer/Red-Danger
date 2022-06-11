using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShapeNumbers : MonoBehaviour
{
    private int redShapes, leftRedShapes, rightRedShapes, upRedShapes, strongRedShapes, leftStrongRedShapes, rightStrongRedShapes, upStrongRedShapes, redBlocks;
    private int redObjects;
    private float timer;
    private float volumeTimer;
    private int soundController = 0;
    private AudioSource music;

    [HideInInspector] public static bool levelCompleted;
    [HideInInspector] public static bool isLoadingCircleActive;

    [Header("Triggers")]
    public GameObject[] triggers;

    [Header("Screens")]
    public Image successMessage;
    public Image failMessage;
    public Image pauseScreen;

    [Header("UI Buttons")]
    public GameObject levelSelectButton;
    public GameObject restartButton;
    public GameObject pauseButton;
    public GameObject helpButton;

    [Header("Loading Circle")]
    public Image loadingCircle;
    public Color dayTimeColor;
    public Color nightColor;

    [Header("Sound")]
    public AudioSource levelCompletedSound;
    public float delayTime = 7.621f;

    [Header("All Shapes")]
    public GameObject[] shapes;
    
    private void Start()
    {
        timer = 5.0f;
        volumeTimer = levelCompletedSound.clip.length;
        music = GameObject.Find("Music Management").GetComponent<AudioSource>();
        loadingCircle.color = Timer.IsDayTime ? dayTimeColor : nightColor;
        loadingCircle.enabled = false;
        isLoadingCircleActive = false;
        levelCompleted = false;
    }

    private void Update()
    {
        redShapes = GameObject.FindGameObjectsWithTag("Red Shape").Count();
        leftRedShapes = GameObject.FindGameObjectsWithTag("Red Shape Left").Count();
        rightRedShapes = GameObject.FindGameObjectsWithTag("Red Shape Right").Count();
        upRedShapes = GameObject.FindGameObjectsWithTag("Red Shape Up").Count();
        strongRedShapes = GameObject.FindGameObjectsWithTag("Strong Red Shape").Count();
        leftStrongRedShapes = GameObject.FindGameObjectsWithTag("Strong Red Shape Left").Count();
        rightStrongRedShapes = GameObject.FindGameObjectsWithTag("Strong Red Shape Right").Count();
        upStrongRedShapes = GameObject.FindGameObjectsWithTag("Strong Red Shape Up").Count();
        redBlocks = GameObject.FindGameObjectsWithTag("Red Block").Count();
        redObjects = redShapes + leftRedShapes + rightRedShapes + upRedShapes + strongRedShapes + leftStrongRedShapes + rightStrongRedShapes + upStrongRedShapes + redBlocks;

        for (int i = 0; i < shapes.Length; i++)
        {
            if (shapes[i] != null)
            {
                Vector2 velocity = shapes[i].GetComponent<Rigidbody2D>().velocity;

                if (velocity.x >= 0.05f || velocity.y >= 0.05f || velocity.x <= -0.05f || velocity.y <= -0.05f)
                {
                    timer = 5.0f;
                }
            }
            else
            {
                continue;
            }
        }

        if (redObjects == 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
            {
                if (!successMessage.IsDestroyed())
                {
                    Destroy(failMessage);
                    Destroy(levelSelectButton);
                    Destroy(restartButton);
                    Destroy(pauseScreen);
                    Destroy(pauseButton);
                    try { Destroy(helpButton); } catch { }
                    successMessage.gameObject.SetActive(true);
                    loadingCircle.enabled = false;
                    isLoadingCircleActive = false;

                    levelCompleted = true;
                    volumeTimer -= Time.deltaTime;
                    music.volume = volumeTimer > 0.0f ? 0.1f : 1.0f;

                    if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("SaveIndex"))
                    {
                        PlayerPrefs.SetInt("SaveIndex", SceneManager.GetActiveScene().buildIndex);
                    }

                    if (soundController == 0)
                    {
                        if (SoundToggle.isToggled)
                        {
                            levelCompletedSound.Play();
                        }
                        soundController = 1;
                    }

                    Destroy(levelCompletedSound, delayTime);
                }
            }
            else
            {
                if (!loadingCircle.IsDestroyed())
                {
                    loadingCircle.enabled = true;
                    isLoadingCircleActive = true;
                }
            }
        }
    }
}