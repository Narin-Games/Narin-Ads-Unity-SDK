#if _tapsell_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using Narin.Unity.Advertisement;
using System;
using TapsellSDK;

public partial class TapsellManager : IAdManager {

    public IInterstitialAd GetInterstitialAd (string zoneId) {
        return new TapsellInterstitialAd(zoneId);
    }

    private class TapsellInterstitialAd : IInterstitialAd {
        public string ZoneId { get { return _zoneId; } }

        private readonly string _zoneId;
        private TapsellAd _currentAd = null;

#pragma warning disable
        public event EventHandler<EventArgs> OnStarted;
        public event EventHandler<EventArgs> OnClosed;
        public event EventHandler<EventArgs> OnLeavingApplication;
#pragma warning restore
        public event EventHandler<EventArgs> OnLoaded;
        public event EventHandler<AdErrorEventArgs> OnError;

        public TapsellInterstitialAd(string zoneId) {
            _zoneId = zoneId;
        }

        public void Load() {
            _currentAd = null;
            Tapsell.RequestAd(_zoneId, false,
                OnAdAvailableHandler, OnNoAdAvailableHandler, OnErrorHandler, OnNoNetworkHandler, OnExpiringHandler);
        }

        public void Show() {
            Tapsell.ShowAd(_currentAd);
            _currentAd = null;
        }

#region _handlers_
        private void OnAdAvailableHandler(TapsellSDK.TapsellAd result) {
            _currentAd = result;
            if (OnLoaded == null) return;
            OnLoaded(this, new EventArgs());
        }

        private void OnNoAdAvailableHandler(string zoneId) {
            string methodName = "OnNoAdAvailableHandler(): ";
            if (OnError == null) return;
            OnError(this, new AdErrorEventArgs(AdError.NoAdAvailable,
                _SCRIPT_NAME + methodName + "No ad available"));
        }

        private void OnErrorHandler(TapsellError error) {
            string methodName = "OnErrorHandler(): ";
            if (OnError == null) return;
            OnError(this, new AdErrorEventArgs(AdError.GeneralError,
                _SCRIPT_NAME + methodName + error.message));
        }

        private void OnNoNetworkHandler(string zoneId) {
            string methodName = "OnNoNetworkHandler(): ";
            OnError(this, new AdErrorEventArgs(AdError.NoInternetConnection,
                _SCRIPT_NAME + methodName + "No internet error"));
        }

        private void OnExpiringHandler(TapsellAd result) {
            string methodName = "OnExpiringHandler(): ";
            OnError(this, new AdErrorEventArgs(AdError.AdExpired,
                _SCRIPT_NAME + methodName + "No internet error"));
        }
#endregion
    }
}

#endif