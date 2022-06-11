using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class AdvertisementSender : MonoBehaviour
{
    [HideInInspector] public static float timer = 0.0f;

    private readonly float period = 450.0f;
    private string adUnitId;

    private InterstitialAd interstitial;
    private static AdvertisementSender instance = null;

    public static AdvertisementSender Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-1416251027882107/3924120029";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-1416251027882107/9668784183";
        #else
            adUnitId = "unexpected_platform";
        #endif

        MobileAds.Initialize(initStatus => { });
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= period && !Rating.isShown)
        {
            if (interstitial != null)
            {
                interstitial.Destroy();
            }

            interstitial = new InterstitialAd(adUnitId);
            interstitial.OnAdLoaded += OnAdLoaded;
            interstitial.OnAdFailedToLoad += OnAdFailedToLoad;
            interstitial.OnAdOpening += OnAdOpening;
            interstitial.OnAdFailedToShow += OnAdFailedToShow;
            interstitial.OnAdClosed += OnAdClosed;

            AdRequest request = new AdRequest.Builder().Build();
            interstitial.LoadAd(request);

            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }

            timer = 0.0f;
        }
    }

    private void OnAdLoaded(object sender, EventArgs args)
    {
    }

    private void OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }

    private void OnAdOpening(object sender, EventArgs args)
    {
    }

    private void OnAdFailedToShow(object sender, AdErrorEventArgs args)
    {
    }

    private void OnAdClosed(object sender, EventArgs args)
    {
    }
}