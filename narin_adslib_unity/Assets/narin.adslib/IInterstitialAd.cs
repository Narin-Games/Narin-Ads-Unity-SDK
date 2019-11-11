using System;

namespace Narin.Unity.Advertisement {
    public enum AdError {
        None
       ,GeneralError
       ,NoInternetConnection
       ,AdExpired
       ,NoAdAvailable
       ,GAM_FailedToLoad
       ,GAM_FailedToShow
    }

    public interface IInterstitialAd {
        string ZoneId {get;}

        void Load();
        void Show();

        event EventHandler<EventArgs>           OnLoaded;
        event EventHandler<EventArgs>           OnStarted;
        event EventHandler<EventArgs>           OnClosed;
        event EventHandler<AdErrorEventArgs>    OnError;
        event EventHandler<EventArgs>           OnLeavingApplication;
    }

    public class AdErrorEventArgs: EventArgs {
        public readonly string Message;
        public readonly AdError ErrorType;

        public AdErrorEventArgs(AdError errorType, string message) {
            Message = message;
            ErrorType = errorType;
        }
    }
}