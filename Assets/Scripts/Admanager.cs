using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class Admanager : MonoBehaviour
{
   string AppId = "ca-app-pub-7011716635953939~6012190064";
   string RewardedAddId = "ca-app-pub-3940256099942544/5224354917";
   private RewardedAd rewardedAd;

   public void Start()
   {

       this.rewardedAd = new RewardedAd(RewardedAddId);
       // Called when an ad request has successfully loaded.
              this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
              // Called when an ad request failed to load.
              this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
              // Called when an ad is shown.
              this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
              // Called when an ad request failed to show.
              this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
              // Called when the user should be rewarded for interacting with the ad.
              this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
              // Called when the ad is closed.
              this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
       // Create an empty ad request.
       AdRequest request = new AdRequest.Builder().Build();
       // Load the rewarded ad with the request.
       this.rewardedAd.LoadAd(request);

   }
   public void HandleRewardedAdLoaded(object sender, EventArgs args)
      {
          MonoBehaviour.print("HandleRewardedAdLoaded event received");

      }

      public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
      {
          MonoBehaviour.print(
              "HandleRewardedAdFailedToLoad event received with message: "
                               + args.Message);
      }

      public void HandleRewardedAdOpening(object sender, EventArgs args)
      {
          MonoBehaviour.print("HandleRewardedAdOpening event received");
      }

      public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
      {
          MonoBehaviour.print(
              "HandleRewardedAdFailedToShow event received with message: "
                               + args.Message);
      }

      public void HandleRewardedAdClosed(object sender, EventArgs args)
      {
          MonoBehaviour.print("HandleRewardedAdClosed event received");
      }

      public void HandleUserEarnedReward(object sender, Reward args)
      {
          string type = args.Type;
          double amount = args.Amount;
          MonoBehaviour.print(
              "HandleRewardedAdRewarded event received for "
                          + amount.ToString() + " " + type);
                              SceneManager.LoadScene(0);
      }

      public void UserChoseToWatchAd()
      {
        if (this.rewardedAd.IsLoaded()) {
          this.rewardedAd.Show();
        }
      }


}
