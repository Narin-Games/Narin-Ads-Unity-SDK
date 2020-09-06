# Narin-Ads-Unity-SDK
This SDK creates an interface for you to use the SDK of different advertising agencies so that you do not need to change your code that you have implemented within your game logic if you need to change your advertising agency. This SDK currently supports 3 different advertising agencies (AdMob, Tapsell and TapsellPlus)

**Advantages:**

1) Designing an interface for the entire Ad Agencies so that the maximum possibilities of these services are covered and at the same time everyone follows a single interface
2) Minimize code changes when replacing Ad Agency
3) Integrate multiple Ad Agencies with just one implementation
4) Can be used in Distributed Build System to use different Ad Agencies for different releases

## How To Use
This system has three stages in its life cycle, which I will explain in order:

**Build --> Initial --> GetAdObject**


### 1) Build:

In this step you need to create an object of type IAdManager through the AdBuilder class to access the Ad Agency API through this object.

You must first provide Ad information to the AdBuilder class, as in the following code example:
