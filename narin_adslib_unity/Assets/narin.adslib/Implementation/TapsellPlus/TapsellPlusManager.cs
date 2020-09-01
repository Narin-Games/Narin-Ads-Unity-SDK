#if _tapsell_plus_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using Narin.Unity.Advertisement;
using TapsellPlusSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TapsellPlusManager : IAdManager {
    public AdData AdData { get { return _adData; }}

    private AdData _adData = new AdData(AdData.TAPSELL_PLUS_KEY);

    public void Init() {
        TapsellPlus.initialize(_adData.AppId);
    }
}

#endif