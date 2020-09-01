#if _tapsell_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using Narin.Unity.Advertisement;
using System;
using TapsellSDK;

public partial class TapsellManager : IAdManager {
    private const string _SCRIPT_NAME = "[TapsellImplementation.cs] --> TapsellManager.";

    public AdData AdData { get { return _adData; } }

    private readonly AdData _adData = new AdData(AdData.TAPSELL_KEY);

    public void Init() {
        Tapsell.Initialize(_adData.AppId);
    }
}

#endif