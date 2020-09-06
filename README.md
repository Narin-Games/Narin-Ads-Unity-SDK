# Narin-Ads-Unity-SDK
This SDK creates an interface for you to use the SDK of different advertising agencies so that you do not need to change your code that you have implemented within your game logic if you need to change your advertising agency. This SDK currently supports 3 different advertising agencies (AdMob, Tapsell and TapsellPlus)

**Advantages:**

1) Designing an interface for the entire Ad Agencies so that the maximum possibilities of these services are covered and at the same time everyone follows a single interface
2) Minimize code changes when replacing Ad Agency
3) Integrate multiple Ad Agencies with just one implementation
4) Can be used in Distributed Build System to use different Ad Agencies for different releases

## How To Use
This system has three stages in its life cycle, which I will explain in order:

**Build --> Initial --> GetAdUnit**


### 1) Build:

In this step you need to create an object of type IAdManager through the AdBuilder class to access the Ad Agency API through this object.

You must first provide Ad information to the AdBuilder class, as in the following code example:

```csharp
public class AdsTest: MonoBehaviour {

  private IAdManager _adManager = null;
  
//...

  private void InitialAdManager() {
      var builder = new AdBuilder();

      _adManager = builder
          .SetAppId(AdAgency.AdMob         , "<AdMobAppId>")
          .SetAppId(AdAgency.Tapsell       , "<TapsellAppId>")
          .SetAppId(AdAgency.TapsellPlus   , "<TapsellPlusAppId>")

          .SetZoneId(AdAgency.AdMob,      TEST_ZONE_NAME, "<AdMobZoneId>")
          .SetZoneId(AdAgency.Tapsell,    TEST_ZONE_NAME, "<TapsellZoneId>")
          .SetZoneId(AdAgency.TapsellPlus,TEST_ZONE_NAME, "<TapsellPlusZoneId>")

          .Build();
  }

//...
}
```

**Notice 1-1:**

The Build stage only needs to happen once when the game is run and after calling **AdBuilder.Build()**, you create a IAdManager component whose reference is stored in the static variable **AdBuilder.CurrentAdManager**.

``` csharp
//This static variable is set after calling IAPBuilder.BuildAndAttach()
AdBuilder.CurrentAdManager
```

**Notice 1-2:**

It is better to perform this step in a separate Scene that is loaded only once in the game.


### 2) Initialize:

Before using any of the IAdManager object methods, We must first initialize the ad manager via the IAdManager.Init() method. after initializing analytics services you can get basic metrics (such as retuntion or session length) in any analytics you initialized.


```csharp
public class AdsTest: MonoBehaviour {

    private IAdManager _adManager = null;
    
    void Start() {
      _adManager = AdBuilder.CurrentAdManager;
      _adManager.Init();
    }
}
```

