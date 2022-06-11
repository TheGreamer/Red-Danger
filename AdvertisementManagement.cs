using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class AdvertisementManagement : MonoBehaviour
{
    [Header("Reward")]
    public GameObject[] solutionObjects;

    private bool hasStarted;
    private float timer;
    private RewardedAd rewardedAd;

    private void Start()
    {
        string adUnitId;

        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-1416251027882107/8966400663";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-1416251027882107/3325694190";
        #else
            adUnitId = "unexpected_platform";
        #endif

        MobileAds.Initialize(initStatus => { });

        rewardedAd = new RewardedAd(adUnitId);
        rewardedAd.OnAdLoaded += OnAdLoaded;
        rewardedAd.OnAdFailedToLoad += OnAdFailedToLoad;
        rewardedAd.OnAdOpening += OnAdOpening;
        rewardedAd.OnAdFailedToShow += OnAdFailedToShow;
        rewardedAd.OnUserEarnedReward += OnUserEarnedReward;
        rewardedAd.OnAdClosed += OnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);

        hasStarted = false;
        timer = 0.0f;
    }

    private void Update()
    {
        if (hasStarted)
        {
            timer += Time.deltaTime;

            try
            {
                for (int i = 0; i < solutionObjects.Length; i++)
                {
                    if (timer >= 1.0f && timer <= 6.0f)
                    {
                        solutionObjects[i].SetActive(true);
                        AdvertisementSender.timer = 0.0f;
                    }
                    else
                    {
                        solutionObjects[i].SetActive(false);
                    }
                }
            }

            catch { }
        }
    }

    public void UserChoseToWatchAd()
    {
        if (rewardedAd.IsLoaded())
        {
            try
            {
                rewardedAd.Show();
                Destroy(GameObject.Find("Advertisement Button"));
            }
            catch { }
        }
    }

    private void OnUserEarnedReward(object sender, Reward args)
    {
        hasStarted = true;
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