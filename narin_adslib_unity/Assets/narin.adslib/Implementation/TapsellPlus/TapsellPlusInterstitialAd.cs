#if _tapsell_plus_ && UNITY_ANDROID || _dev_ && UNITY_ANDROID

using System;
using TapsellPlusSDK;

namespace Narin.Unity.Advertisement {
public partial class AdBuilder {

    private partial class TapsellPlusManager : IAdManager {
    
        public IInterstitialAd GetInterstitialAd(string zoneId) {
            return new TapsellPlusInterstitialAd(zoneId);
        }
    
        public class TapsellPlusInterstitialAd : IInterstitialAd {
            public string ZoneId { get { return _zoneId; }}
    
            public event EventHandler<EventArgs> OnLoaded;
            public event EventHandler<EventArgs> OnStarted;
            public event EventHandler<EventArgs> OnClosed;
            public event EventHandler<AdErrorEventArgs> OnError;
#pragma warning disable 67
            public event EventHandler<EventArgs> OnLeavingApplication;
#pragma warning restore 67
            protected readonly string _zoneId;
    
            public TapsellPlusInterstitialAd(string zoneId) {
                _zoneId = zoneId;
            }
    
            public virtual void Load() {
                TapsellPlus.requestInterstitial(_zoneId, OnRequestResponseHandler, OnRequestErrorHandler);   
            }
    
            public virtual void Show() {
                TapsellPlus.showAd(_zoneId
                    , OnShowAdHandler
                    , OnCloseAdHandler
                    , null
                    , OnErrorHandler
                    );
            }
    
            #region _handlers_
            protected void OnRequestResponseHandler(string zoneId) {
                if(null == OnLoaded) return;
                OnLoaded(this, new EventArgs());
            }
    
            protected void OnRequestErrorHandler(TapsellError error) {
                if(null == OnError) return;
                OnError(this, new AdErrorEventArgs(AdError.GeneralError, error.message));
            }
    
            protected void OnShowAdHandler(string zoneId) {
                if(null == OnStarted) return;
                OnStarted(this, new EventArgs());
            }
    
            protected void OnCloseAdHandler(string zoneId) {
                if(null == OnClosed) return;
                OnClosed(this, new EventArgs());
            }
    
            protected void OnErrorHandler(TapsellError error) {
                if(null == OnError) return;
                OnError(this, new AdErrorEventArgs(AdError.GeneralError, error.message));
            }
            #endregion
        }
    }

}
}
#endif