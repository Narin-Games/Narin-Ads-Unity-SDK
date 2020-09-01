#if _google_admob_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using Narin.Unity.Advertisement;
using gmd = GoogleMobileAds.Api;
using System;

public partial class AdMobManager : IAdManager {
    public IRewardedAd GetRewardedAd(string zoneId) {
        return new AdMobRewardedAd(zoneId);
    }

    private class AdMobRewardedAd : IRewardedAd {

        public string ZoneId { get{return _zoneId; } }

        public event EventHandler<AdRewardEventArgs> OnEarnedReward;
        public event EventHandler<EventArgs> OnLoaded;
        public event EventHandler<EventArgs> OnStarted;
        public event EventHandler<EventArgs> OnClosed;
        public event EventHandler<AdErrorEventArgs> OnError;
        public event EventHandler<EventArgs> OnLeavingApplication;

        private readonly string _zoneId;
        private readonly gmd.RewardedAd _ad;

        public AdMobRewardedAd(string zoneId) {
            _zoneId = zoneId;
            _ad = new gmd.RewardedAd(_zoneId);

            _ad.OnAdLoaded              += OnAdLoadedHandler;
            _ad.OnAdFailedToLoad        += OnFailedToLoadHandler;
            _ad.OnAdOpening             += OnAdOpeningHandler;
            _ad.OnAdFailedToShow        += OnAdFailedToShowHandler;
            _ad.OnAdClosed              += OnAdClosedHandler;
            _ad.OnUserEarnedReward      += OnUserEarnedRewardHandler;
        }

        ~AdMobRewardedAd() {
            _ad.OnAdLoaded              -= OnAdLoadedHandler;
            _ad.OnAdFailedToLoad        -= OnFailedToLoadHandler;
            _ad.OnAdOpening             -= OnAdOpeningHandler;
            _ad.OnAdFailedToShow        -= OnAdFailedToShowHandler;
            _ad.OnAdClosed              -= OnAdClosedHandler;
            _ad.OnUserEarnedReward      -= OnUserEarnedRewardHandler;
        }

        public void Load() {
            _ad.LoadAd(new gmd.AdRequest.Builder().Build());
        }

        public void Show() {
            if(_ad.IsLoaded()) _ad.Show();
        }

#region _handlers_
        private void OnAdLoadedHandler(object sender, EventArgs e) {
            if(null != OnLoaded)
                OnLoaded(this, e);
        }

        private void OnFailedToLoadHandler(object sender, gmd.AdErrorEventArgs e) {
            if(null != OnError)
                OnError(this, new AdErrorEventArgs(AdError.GAM_FailedToLoad, e.Message));
        }

        private void OnAdOpeningHandler(object sender, EventArgs e) {
            if(null != OnStarted)
                OnStarted(this, e);
        }

        private void OnAdFailedToShowHandler(object sender, gmd.AdErrorEventArgs e) {
            if (null != OnError)
                OnError(this, new AdErrorEventArgs(AdError.GAM_FailedToShow, e.Message));
        }

        private void OnAdClosedHandler(object sender, EventArgs e) {
            if(null != OnClosed)
                OnClosed(this, e);
        }

        private void OnLeavingApplicationHandler(object sender, EventArgs e) {
            if(null != OnLeavingApplication)
                OnLeavingApplication(this, e);
        }

        private void OnUserEarnedRewardHandler(object sender, gmd.Reward e) {
            if(null != OnEarnedReward)
                OnEarnedReward(this, new AdRewardEventArgs(e.Type, (int)e.Amount));
        }
#endregion
    }
}

#endif