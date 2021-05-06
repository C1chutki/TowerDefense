using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityMonetization : MonoBehaviour, IUnityAdsListener
{
    string gameId = "3985099";
    public bool testMode = true;
    string RewardedVideo = "rewardedVideo";
    string SkippableAd = "video";
    //public string surfacingId = "bannerPlacement";

    Upgrades upgrades;
    ClickUpgrades clickUpgrades;
    SimpleTurretUpgrade simpleTurretUpgrade;
    RocketTurretUpgrade RocketTurretUpgrade;


    void Start()
    {
        upgrades = FindObjectOfType<Upgrades>();
        clickUpgrades = FindObjectOfType<ClickUpgrades>();
        simpleTurretUpgrade = FindObjectOfType<SimpleTurretUpgrade>();
        RocketTurretUpgrade = FindObjectOfType<RocketTurretUpgrade>();

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);


        //StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    }

    //public void ShowAd(string p)
    //{
    //    Advertisement.Show(p);
    //}

    //IEnumerator ShowBannerWhenInitialized()
    //{
    //    while (!Advertisement.isInitialized)
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //    Advertisement.Banner.Show(surfacingId);
    //}

    public void DisplayInterstitialAD()
    {
        Advertisement.Show(SkippableAd);
    }

    public void DisplayVideoAD()
    {
        Advertisement.Show(RewardedVideo);
    }


    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            if (surfacingId == SkippableAd) { Debug.LogWarning("video ad"); }
            if (surfacingId == RewardedVideo) { 
                Debug.LogWarning("rewarded ad");
                upgrades.GetGems();
                clickUpgrades.ClickpwrCheck();
                simpleTurretUpgrade.upgradecheck();
                RocketTurretUpgrade.upgradecheck();
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            Debug.LogWarning("You skipped ad");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == RewardedVideo)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
