#if _tapsell_plus_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using System.Collections.Generic;
using TapsellPlusSDK;

namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class TapsellPlusManager : IAdManager {
        
        private string _appId = null;
        private Dictionary<string, string> _zoneIds = null;

        public TapsellPlusManager(string appId, Dictionary<string, string> zoneIds) {
            _appId = appId;
            _zoneIds = zoneIds;
        }

        public void Init() {
            TapsellPlus.initialize(_appId);
        }
    }
}
}
#endif