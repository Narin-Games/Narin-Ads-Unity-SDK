#if _google_admob_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using System.Collections.Generic;
using gmd = GoogleMobileAds.Api;

namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class AdMobManager: IAdManager {

        private string _appId = null;
        private Dictionary<string, string> _zoneIds;

        public AdMobManager(string appId, Dictionary<string, string> zoneIds) {
            _appId = appId;
            _zoneIds = zoneIds;
        }
        
        public void Init() {
            gmd.MobileAds.Initialize(_appId);
        }
    }

}
}

#endif