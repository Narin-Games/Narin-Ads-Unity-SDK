#if _tapsell_plus_ && UNITY_ANDROID

using Narin.Unity.Advertisement;
using System;
using TapsellPlusSDK;


public partial class TapsellPlusManager : IAdManager {
    public IRewardedAd GetRewardedAd(string zoneId) {
        return new TapsellPlusRewardedAd(zoneId);
    }

    private class TapsellPlusRewardedAd : TapsellPlusInterstitialAd, IRewardedAd {

        public event EventHandler<AdRewardEventArgs> OnEarnedReward;


        public TapsellPlusRewardedAd(string zoneId): base(zoneId) { }

        public override void Load() {
            TapsellPlus.requestRewardedVideo(_zoneId
                , OnRequestResponseHandler
                , OnRequestErrorHandler
                );
        }

        public override void Show() {
            TapsellPlus.showAd(_zoneId
                , OnShowAdHandler
                , OnCloseAdHandler
                , OnRewardHandler
                , OnErrorHandler
                );
        }

#region _handlers_
        private void OnRewardHandler(string zoneId) {
            if(null == OnEarnedReward) return;
            OnEarnedReward(this, new AdRewardEventArgs());
        }
#endregion
    }
}

#endif