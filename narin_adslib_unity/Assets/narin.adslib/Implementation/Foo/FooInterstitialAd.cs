#if _foo_ || _dev_ && UNITY_ANDROID

using Narin.Unity.Advertisement;
using System;

public partial class FooManager : IAdManager {

    public IInterstitialAd GetInterstitialAd(string zoneId) {
        return new FooInterstitialAd();
    }

    private class FooInterstitialAd : IInterstitialAd {
        public string ZoneId {
            get {
                return "FooZoneId";
            }
        }

        public event EventHandler<EventArgs> OnLoaded;
        public event EventHandler<EventArgs> OnStarted;
        public event EventHandler<EventArgs> OnClosed;
        public event EventHandler<AdErrorEventArgs> OnError;
        public event EventHandler<EventArgs> OnLeavingApplication;

        public void Load() {
            
        }

        public void Show() {
            
        }
    }

}

#endif