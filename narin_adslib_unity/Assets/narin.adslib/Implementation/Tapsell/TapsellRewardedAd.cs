#if _tapsell_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using Narin.Unity.Advertisement;
using System;
using TapsellSDK;

public partial class TapsellManager : IAdManager {

    public IRewardedAd GetRewardedAd(string zoneId) {
        return new TapsellRewardedAd(zoneId);
    }

    private class TapsellRewardedAd : TapsellInterstitialAd, IRewardedAd {
        private static event Action<TapsellAdFinishedResult> OnEarnedRewardGlobal;
        private static bool _isGlobalHandlerSet = false;

        public event EventHandler<AdRewardEventArgs> OnEarnedReward;

        public TapsellRewardedAd(string zoneId) : base(zoneId) {
            if(_isGlobalHandlerSet) {
                Tapsell.SetRewardListener(OnEarnedRewardGlobal);
                _isGlobalHandlerSet = true;
            }

            OnEarnedRewardGlobal += OnEarnedRewardHandler;
        }

        ~TapsellRewardedAd() {
            OnEarnedRewardGlobal -= OnEarnedRewardHandler;
        }

        private void OnEarnedRewardHandler(TapsellAdFinishedResult reward) {
            if (OnEarnedReward == null) return;

            if (reward.rewarded && reward.completed)
                OnEarnedReward(this, new AdRewardEventArgs());
        }
    }
}

#endif