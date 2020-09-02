namespace Narin.Unity.Advertisement {

    public interface IAdManager {
        void Init();
        IInterstitialAd GetInterstitialAd (string zoneName);
        IRewardedAd GetRewardedAd (string zoneName);
    }
}