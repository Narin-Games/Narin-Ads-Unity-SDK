using UnityEngine;
using Narin.Unity.Advertisement;

public class AdsTest: MonoBehaviour {

    private IInterstitialAd _videoAd;
    private bool _isInit = false;
    private IAdManager _adManager = null;
    private const string TEST_ZONE_NAME = "TestVideoAdZone";

    void Start() {
        if(true == _isInit) return;

        InitialAdManager();

        _adManager.Init();
        _videoAd = _adManager.GetRewardedAd(TEST_ZONE_NAME);
        _isInit = true;
    }

    void OnEnable() {
        if(_isInit != true) Start();

        Debug.Log("events subscribed");
        _videoAd.OnClosed       += OnAdClosed;
        _videoAd.OnLoaded       += OnAdLoaded;
        _videoAd.OnStarted      += OnAdOpening;
        _videoAd.OnError        += OnAdError;
    }

    void OnDisable() {
        Debug.Log("events unsubscribed");
        _videoAd.OnClosed       -= OnAdClosed;
        _videoAd.OnLoaded       -= OnAdLoaded;
        _videoAd.OnStarted      -= OnAdOpening;
        _videoAd.OnError        -= OnAdError;
    }

    public void RequestAd_OnClick() {
        print("request is sent");
        _videoAd.Load();
    }

    public void ShowAd_OnClick() {
        _videoAd.Show();
    }

    private void InitialAdManager() {
        var builder = new AdBuilder();

        _adManager = builder
            .SetAppId(AdAgency.AdMob         , "<AdMobAppId>")
            .SetAppId(AdAgency.Tapsell       , "<TapsellAppId>")
            .SetAppId(AdAgency.TapsellPlus   , "<TapsellPlusAppId>")

            .SetZoneId(AdAgency.AdMob,      TEST_ZONE_NAME, "<AdMobZoneId>")
            .SetZoneId(AdAgency.Tapsell,    TEST_ZONE_NAME, "<TapsellZoneId>")
            .SetZoneId(AdAgency.TapsellPlus,TEST_ZONE_NAME, "<TapsellPlusZoneId>")

            .Build();
    }

    private void OnAdStarted(object sender, System.EventArgs e) {
        print("ad started");
    }

    private void OnAdOpening(object sender, System.EventArgs e) {
        print("ad opening");
    }

    private void OnAdLoaded(object sender, System.EventArgs e) {
        print("ad loaded");
    }

    private void OnAdLeavingApplication(object sender, System.EventArgs e) {
        print("ad leaving application");
    }

    private void OnAdCompleted(object sender, System.EventArgs e) {
        print("ad completed");
    }

    private void OnAdClosed(object sender, System.EventArgs e) {
        print("ad closed");
    }

    private void OnAdFailedToLoad(object sender, AdErrorEventArgs e) {
        print("ad failed to load: " + e.Message);
    }

    private void OnAdError(object sender, AdErrorEventArgs e) {
        print("ad error: " + e.Message);
    }
}