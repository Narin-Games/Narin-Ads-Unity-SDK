#if _foo_ || _dev_ && UNITY_ANDROID


namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class FooManager : IAdManager {
        private AdData data = new AdData(AdData.FOO);
    
        public AdData AdData {
            get {
                return data;
            }
        }
    }

}
}
#endif