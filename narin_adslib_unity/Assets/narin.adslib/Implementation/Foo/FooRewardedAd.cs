﻿#if _foo_

using Narin.Unity.Advertisement;
using System;

public partial class FooManager : IAdManager {

    public IRewardedAd GetRewardedAd(string zoneId) {
        return new FooRewardedAd();
    }

    public void Init() {
        
    }

    private class FooRewardedAd : IRewardedAd {
        public string ZoneId {
            get{ return "FooZoneId"; }
        }

        public event EventHandler<AdRewardEventArgs> OnEarnedReward;
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