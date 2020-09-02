#if _google_admob_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using gmd = GoogleMobileAds.Api;
using System;

namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class AdMobManager : IAdManager {

        public IInterstitialAd GetInterstitialAd(string zoneName) {
            return new AdMobInterstitialAd(_zoneIds[zoneName]);
        }

        private class AdMobInterstitialAd : IInterstitialAd {
            public string ZoneId { get { return _zoneId; } }
            private readonly string _zoneId = null;
            private gmd.InterstitialAd _ad;

            public event EventHandler<EventArgs> OnLoaded;
            public event EventHandler<EventArgs> OnStarted;
            public event EventHandler<EventArgs> OnClosed;
            public event EventHandler<AdErrorEventArgs> OnError;
            public event EventHandler<EventArgs> OnLeavingApplication;

            public AdMobInterstitialAd(string zoneId) {
                _zoneId = zoneId;
                
                _ad = new gmd.InterstitialAd(zoneId);
                
                _ad.OnAdLoaded              += OnAdLoadedHandler;
                _ad.OnAdFailedToLoad        += OnFailedToLoadHandler;
                _ad.OnAdOpening             += OnAdOpeningHandler;
                _ad.OnAdClosed              += OnAdClosedHandler;
                _ad.OnAdLeavingApplication  += OnLeavingApplicationHandler;
            }

            ~AdMobInterstitialAd() {
                _ad.OnAdLoaded              -= OnAdLoadedHandler;
                _ad.OnAdFailedToLoad        -= OnFailedToLoadHandler;
                _ad.OnAdOpening             -= OnAdOpeningHandler;
                _ad.OnAdClosed              -= OnAdClosedHandler;
                _ad.OnAdLeavingApplication  -= OnLeavingApplicationHandler;
            }

            public void Load() {
                _ad.LoadAd(new gmd.AdRequest.Builder().Build());
            }

            public void Show() {
                if (_ad.IsLoaded()) _ad.Show();
            }

#region _handlers_
            private void OnAdLoadedHandler(object sender, EventArgs e) {
                if (null != OnLoaded)
                    OnLoaded(this, e);
            }

            private void OnFailedToLoadHandler(object sender, gmd.AdFailedToLoadEventArgs e) {
                if (null != OnError)
                    OnError(this, new AdErrorEventArgs(AdError.GAM_FailedToLoad, e.Message));
            }

            private void OnAdOpeningHandler(object sender, EventArgs e) {
                if (null != OnStarted)
                    OnStarted(this, e);
            }

            private void OnAdClosedHandler(object sender, EventArgs e) {
                if (null != OnClosed)
                    OnClosed(this, e);
            }

            private void OnLeavingApplicationHandler(object sender, EventArgs e) {
                if(null != OnLeavingApplication)
                    OnLeavingApplication(this, e);
            }
#endregion
        }
    }
}
}
#endif