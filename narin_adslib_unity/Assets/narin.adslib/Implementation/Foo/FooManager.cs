#if _foo_

using Narin.Unity.Advertisement;

public partial class FooManager : IAdManager {
    private AdData data = new AdData(AdData.FOO);

    public AdData AdData {
        get {
            return data;
        }
    }
}

#endif