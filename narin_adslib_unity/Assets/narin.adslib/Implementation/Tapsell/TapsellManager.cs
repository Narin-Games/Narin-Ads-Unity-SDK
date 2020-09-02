#if _tapsell_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using System.Collections.Generic;
using TapsellSDK;

namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class TapsellManager : IAdManager {

        private const string _SCRIPT_NAME = "[TapsellImplementation.cs] --> TapsellManager.";
    
        private string _appId = null;
        private Dictionary<string, string> _zoneIds = new Dictionary<string, string>();
        
        public TapsellManager(string appId, Dictionary<string, string> zoneIds) {
            _appId  = appId;
            _zoneIds = zoneIds;
        }

        public void Init() {
            Tapsell.Initialize(_appId);
        }
    }
}
}
#endif