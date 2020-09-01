#if _foo_ || _dev_ && UNITY_ANDROID

using Narin.Unity.Advertisement;
using System;

namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class FooManager : IAdManager {

        public IInterstitialAd GetInterstitialAd(string zoneId) {
            return new FooInterstitialAd();
        }

        private class FooInterstitialAd : IInterstitialAd {
            public string ZoneId {
                get {
                    return "FooZoneId";
                }
            }
#pragma warning disable 67
            public event EventHandler<EventArgs> OnLoaded;
            public event EventHandler<EventArgs> OnStarted;
            public event EventHandler<EventArgs> OnClosed;
            public event EventHandler<AdErrorEventArgs> OnError;
            public event EventHandler<EventArgs> OnLeavingApplication;
#pragma warning restore 67
            public void Load() {
                
            }

            public void Show() {
                
            }
        }
    }
}
}

#endif