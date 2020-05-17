using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdData {
    public const string TAPSELL_KEY             = "Tapsell";
    public const string ADMOB_KEY               = "Admob";
    public const string TAPSELL_PLUS_KEY        = "TapsellPlus";
    public const string FOO                     = "Foo";   

    private readonly string _key;

    public string AppId {
        get { return _appId[_key]; }
    }
    private readonly Dictionary<string, string> _appId = new Dictionary<string, string> {
         {TAPSELL_KEY,              "emnfogmthcaalseikpbsnrfkrsbtnagdesdatbqkgiapnricghdlgrsqafnkptjtnbbajn" }
        ,{ADMOB_KEY,                "ca-app-pub-8088702838125884~3467682544" }
        ,{TAPSELL_PLUS_KEY,         "nlhchmcjijprogqpamigsrqsthmoiaffrimdsoqpesfrcqrgpoannijjabpngtgfhqiogh" }
        ,{FOO,                      "" }
    };

    public string RewardedVideoTest {
        get { return _rewardedVideoTest[_key]; }
    }
    private readonly Dictionary<string, string> _rewardedVideoTest = new Dictionary<string, string> {
         {TAPSELL_KEY,              "" }
        ,{ADMOB_KEY,                "ca-app-pub-3940256099942544/5224354917" }
        ,{TAPSELL_PLUS_KEY,         "5cfaa802e8d17f0001ffb28e" }
        ,{FOO,                      "" }
    };

    public string RewardedVideoGameOverDialog {
        get { return _rewardedVideoGameOverDialog[_key]; }
    }
    private readonly Dictionary<string, string> _rewardedVideoGameOverDialog = new Dictionary<string, string> {
         {TAPSELL_KEY,              "" }
        ,{ADMOB_KEY,                "ca-app-pub-8088702838125884/6832212489" }
        ,{TAPSELL_PLUS_KEY,         "5ebfa055b81da100018196d3" }
        ,{FOO,                      "" }
    };

    public string RewardedVideoDialogIdleEarn {
        get { return _rewardedVideoDialogIdleEarn[_key]; }
    }
    private readonly Dictionary<string, string> _rewardedVideoDialogIdleEarn = new Dictionary<string, string> {
         {TAPSELL_KEY,              "" }
        ,{ADMOB_KEY,                "ca-app-pub-8088702838125884/5109572249" }
        ,{TAPSELL_PLUS_KEY,         "5ebfa10ab81da100018196d4" }
        ,{FOO,                      "" }
    };

    public string RewardedVideoDialogSecondChance {
        get { return _rewardedVideoDialogSecondChance[_key]; }
    }
    private readonly Dictionary<string, string> _rewardedVideoDialogSecondChance = new Dictionary<string, string> {
         {TAPSELL_KEY,              "" }
        ,{ADMOB_KEY,                "ca-app-pub-8088702838125884/9908750581" }
        ,{TAPSELL_PLUS_KEY,         "5ebfa226b81da100018196d6" }
        ,{FOO,                      "" }
    };

    public string RewardedVideoDialogAdDailyReward {
        get { return _rewardedVideoDialogAdDailyReward[_key]; }
    }
    private readonly Dictionary<string, string> _rewardedVideoDialogAdDailyReward = new Dictionary<string, string> {
         {TAPSELL_KEY,              "" }
        ,{ADMOB_KEY,                "ca-app-pub-8088702838125884/3796490575" }
        ,{TAPSELL_PLUS_KEY,         "5ebf9e8bdae070000171e215" }
        ,{FOO,                      "" }
    };

    public AdData(string key) {
        _key = key;
    }
}