using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdData {
    public const string TAPSELL_KEY = "Tapsell";
    public const string ADMOB_KEY   = "Admob";

    public string AppId {
        get { return _appIdDict[_key]; }
    }

    public string rewardedVideo {
        get { return _rewardedVideo[_key]; }
    }

    private readonly string _key;
    private readonly Dictionary<string, string> _appIdDict = new Dictionary<string, string> {
         {TAPSELL_KEY,   "emnfogmthcaalseikpbsnrfkrsbtnagdesdatbqkgiapnricghdlgrsqafnkptjtnbbajn" }
        ,{ADMOB_KEY,     "ca-app-pub-8088702838125884~3467682544" }
    };

    private readonly Dictionary<string, string> _rewardedVideo = new Dictionary<string, string> {
         {TAPSELL_KEY,   "5db3efb43d194b0001e38c0e" }
        ,{ADMOB_KEY,     "ca-app-pub-8088702838125884/6832212489" }
    };
    
    public AdData(string key) {
        _key = key;
    }
}