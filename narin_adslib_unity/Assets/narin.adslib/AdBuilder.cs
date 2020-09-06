using System.Collections.Generic;

namespace Narin.Unity.Advertisement {

    public enum AdAgency {
        AdMob, Tapsell, TapsellPlus, Foo
    }

    public partial class AdBuilder {
        public static IAdManager CurrentAdManager { get; private set; }

        private Dictionary<AdAgency, string> _appIds = new Dictionary<AdAgency, string>();
        private Dictionary<AdAgency, Dictionary<string, string>> _zoneIds = new Dictionary<AdAgency, Dictionary<string, string>>();

        public AdBuilder SetAppId(AdAgency adAgency, string appId) {
            _appIds.Add(adAgency, appId);
            return this;
        }

        public AdBuilder SetZoneId (AdAgency adAgency, string zoneName, string zoneId) {

            if(_zoneIds.ContainsKey(adAgency)) {
                _zoneIds[adAgency].Add(zoneName, zoneId);
            }
            else {
                _zoneIds.Add(adAgency, new Dictionary<string, string>() { {zoneName, zoneId} });
            }

            return this;
        }

        public IAdManager Build() {
            IAdManager ret = null;

            #if _dev_ || _google_admob_
            ret = new AdMobManager(_appIds[AdAgency.AdMob], _zoneIds[AdAgency.AdMob]);
            #endif

            #if _dev_ || _tapsell_
            ret = new TapsellManager(_appIds[AdAgency.Tapsell], _zoneIds[AdAgency.Tapsell]);
            #endif

            #if _dev_ || _tapsell_plus_
            ret = new TapsellPlusManager(_appIds[AdAgency.TapsellPlus], _zoneIds[AdAgency.TapsellPlus]);
            #endif

            #if _dev_ || _foo_
            ret = new FooManager();
            #endif

            CurrentAdManager = ret;

            return ret;
        }
    }
}