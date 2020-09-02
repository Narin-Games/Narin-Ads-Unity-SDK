#if _foo_ || _dev_ && UNITY_ANDROID

using System;

namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class FooManager : IAdManager {
    
        public IRewardedAd GetRewardedAd(string zoneName) {
            return new FooRewardedAd();
        }
    
        public void Init() {
            
        }
    
        private class FooRewardedAd : IRewardedAd {
            public string ZoneId {
                get{ return "FooZoneId"; }
            }
    #pragma warning disable 67
            public event EventHandler<AdRewardEventArgs> OnEarnedReward;
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