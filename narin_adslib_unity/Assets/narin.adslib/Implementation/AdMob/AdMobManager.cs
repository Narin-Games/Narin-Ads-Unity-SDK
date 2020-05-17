#if _google_admob_ && UNITY_ANDROID

using Narin.Unity.Advertisement;
using gmd = GoogleMobileAds.Api;
using System;

public partial class AdMobManager: IAdManager {
    public AdData AdData {
        get { return _adData; }
    }

    private AdData _adData = new AdData(AdData.ADMOB_KEY);

    public void Init() {
        gmd.MobileAds.Initialize(_adData.AppId);
    }
}

#endif