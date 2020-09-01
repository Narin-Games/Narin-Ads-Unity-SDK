#if _tapsell_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using TapsellSDK;

namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class TapsellManager : IAdManager {

        private const string _SCRIPT_NAME = "[TapsellImplementation.cs] --> TapsellManager.";
    
        public AdData AdData { get { return _adData; } }
    
        private readonly AdData _adData = new AdData(AdData.TAPSELL_KEY);
    
        public void Init() {
            Tapsell.Initialize(_adData.AppId);
        }

    }
}
}
#endif