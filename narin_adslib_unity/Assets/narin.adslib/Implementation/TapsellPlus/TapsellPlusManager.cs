#if _tapsell_plus_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using TapsellPlusSDK;

namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class TapsellPlusManager : IAdManager {

        public AdData AdData { get { return _adData; }}
    
        private AdData _adData = new AdData(AdData.TAPSELL_PLUS_KEY);
    
        public void Init() {
            TapsellPlus.initialize(_adData.AppId);
        }

    }

}
}
#endif