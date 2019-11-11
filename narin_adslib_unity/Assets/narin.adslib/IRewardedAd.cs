using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Narin.Unity.Advertisement {

    public class AdRewardEventArgs : EventArgs {
        public const string DEFAULT_TYPE = "Not Set";
        public const int DEFAULT_AMOUNT = -1;

        public readonly string Type;
        public readonly int Amount;

        public AdRewardEventArgs(string type = DEFAULT_TYPE, int amount = DEFAULT_AMOUNT) {
            Type = type;
            Amount = amount;
        }
    }

    public interface IRewardedAd: IInterstitialAd {
        event EventHandler<AdRewardEventArgs> OnEarnedReward;
    }
}
