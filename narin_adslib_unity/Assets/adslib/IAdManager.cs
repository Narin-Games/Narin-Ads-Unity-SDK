namespace Narin.Unity.Advertisement {

    public interface IAdManager {
        AdData AdData {get;}
        void Init();
        IInterstitialAd GetInterstialAd (string zoneId);
        IRewardedAd GetRewardedAd (string zoneId);
    }
}