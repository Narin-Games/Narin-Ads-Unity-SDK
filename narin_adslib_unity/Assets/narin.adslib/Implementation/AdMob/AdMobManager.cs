#if _google_admob_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using gmd = GoogleMobileAds.Api;

namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class AdMobManager: IAdManager {

        public AdData AdData {
            get { return _adData; }
        }
    
        private AdData _adData = new AdData(AdData.ADMOB_KEY);
    
        public void Init() {
            gmd.MobileAds.Initialize(_adData.AppId);
        }
    }

}
}

#endif