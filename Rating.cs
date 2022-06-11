using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rating : MonoBehaviour
{
	[Header("Screen")]
	public GameObject ratingScreen;

	[Header("UI Buttons")]
	public GameObject levelSelectButton;
	public GameObject restartButton;
	public GameObject pauseButton;
	public GameObject helpButton;

	[Header("Colors")]
	public Color normalColor;
	public Color blackColor;

	[HideInInspector]
	public static bool isShown;

	private const string showNumberKey = "RatingShowNumber";
	private const string ratedKey = "Rated";
	private float timer = 2.0f;
	private Image canvasImage;
	private AudioSource audioSource;

    private void Start()
    {
		canvasImage = GameObject.Find("Canvas").GetComponent<Image>();
		audioSource = GameObject.Find("Music Management").GetComponent<AudioSource>();
    }

    private void Update()
    {
		if (ratingScreen != null)
		{
			if (timer <= 0.0f && !ratingScreen.activeSelf)
			{
				if (SceneManager.GetActiveScene().buildIndex % PlayerPrefs.GetInt(showNumberKey, 10) == 0 && PlayerPrefs.GetInt(ratedKey, 0) == 0)
				{
					SetRatingSettings(true, true, true, blackColor, false, false, false, false, 0.25f, true);
				}
			}
			else
			{
				timer -= Time.deltaTime;
			}
		}
    }
	
	public void RateLater()
	{
		SetRatingSettings(false, false, false, normalColor, true, true, true, true, 1f, false);
		PlayerPrefs.SetInt(showNumberKey, PlayerPrefs.GetInt(showNumberKey) + 10);
	}

	public void GoToGamePage()
	{
		if (ratingScreen != null)
		{
			SetRatingSettings(false, false, false, normalColor, true, true, true, true, 1f, false);
		}

		PlayerPrefs.SetInt(ratedKey, 1);

		#if UNITY_ANDROID
			Application.OpenURL("market://details?id=" + Application.identifier);
		#elif UNITY_IPHONE
			Application.OpenURL("itms-apps://itunes.apple.com/app/" + Application.identifier);
		#endif
	}

	private void SetRatingSettings(bool _isShown, bool _ratingScreen, bool _canvasImageEnabled, Color _canvasImage, bool _levelSelectButton, bool _restartButton, bool _pauseButton, bool _helpButton, float timeScale, bool decreaseVolume)
	{
		Time.timeScale = timeScale;
		isShown = _isShown;
		ratingScreen.SetActive(_ratingScreen);
		canvasImage.enabled = _canvasImageEnabled;
		canvasImage.color = _canvasImage;
		levelSelectButton.SetActive(_levelSelectButton);
		restartButton.SetActive(_restartButton);
		pauseButton.SetActive(_pauseButton);

		if (helpButton != null)
			helpButton.SetActive(_helpButton);

		audioSource.volume = decreaseVolume ? 0.25f : 1.0f;
    }
}