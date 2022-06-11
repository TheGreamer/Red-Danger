using UnityEngine;

public class FaceManagement : MonoBehaviour
{
    public GameObject normalFace, fallingFace;
    public AudioSource fallingSound;

    private float time;
    private float soundTimer;
    private float speed;
    private int soundController;
    private Vector3 oldPosition;

    private void Awake()
    {
        time = 0.0f;
        soundTimer = 0.5f;
        soundController = 0;
    }

    private void Update()
    {
        speed = Vector3.Distance(oldPosition, transform.position) * 100.0f;
        oldPosition = transform.position;

        if (speed >= 5.0f)
        {
            normalFace.SetActive(false);
            fallingFace.SetActive(true);

            if (soundController == 0 && !gameObject.tag.Contains("Blue"))
            {
                if (SoundToggle.isToggled)
                {
                    fallingSound.enabled = true;
                    fallingSound.Play();
                }
                soundController = 1;
            }
        }
        else
        {
            if (time >= 0.0f)
            {
                time -= Time.deltaTime;
            }
            else
            {
                normalFace.SetActive(true);
                fallingFace.SetActive(false);
                time = 3.5f;

                if (!gameObject.tag.Contains("Blue"))
                {
                    fallingSound.enabled = false;
                    soundController = 0;
                }
            }
        }

        if (!gameObject.tag.Contains("Blue"))
        {
            if (soundTimer > 0.0f)
            {
                fallingSound.volume = 0.0f;
                soundTimer -= Time.deltaTime;
            }
            else
            {
                float shapeSize = transform.localScale.x;

                if (ShapeNumbers.levelCompleted || Trigger.levelFailed)
                {
                    fallingSound.volume = 0.25f;
                }
                else
                {
                    if (shapeSize <= 0.15f)
                    {
                        fallingSound.volume = 0.5f;
                    }
                    else if (shapeSize > 0.15f && shapeSize <= 0.2f)
                    {
                        fallingSound.volume = 0.6f;
                    }
                    else if (shapeSize > 0.2f && shapeSize <= 0.3f)
                    {
                        fallingSound.volume = 0.7f;
                    }
                    else if (shapeSize > 0.3f && shapeSize <= 0.4f)
                    {
                        fallingSound.volume = 0.8f;
                    }
                    else
                    {
                        fallingSound.volume = 1.0f;
                    }
                }

                if (MenuManagement.isPaused)
                {
                    fallingSound.Pause();
                }
                else
                {
                    fallingSound.UnPause();
                }
            }
        }
    }
}