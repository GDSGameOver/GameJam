using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;


public class AdSettings : MonoBehaviour, IInterstitialAdListener, IBannerAdListener, IMrecAdListener
{
    private const string AddKey = "13bb6605f6e10626d184f254d4e956dc5f26562d7efe978b";

    private void Start()
    {
        int adTypes = Appodeal.INTERSTITIAL | Appodeal.BANNER_BOTTOM | Appodeal.MREC;
        Appodeal.initialize(AddKey, adTypes, true);

        Appodeal.setInterstitialCallbacks(this);
        Appodeal.setBannerCallbacks(this);
        Appodeal.setMrecCallbacks(this);

    }

    public void ShowInterstitial()
    {
        if (Appodeal.canShow(Appodeal.INTERSTITIAL) && !Appodeal.isPrecache(Appodeal.INTERSTITIAL))
        {
            Appodeal.show(Appodeal.INTERSTITIAL, "");
            Debug.Log("Adshow");
        }
    }

    public void ShowMrecVideo()
    {
        int yAxis = Screen.currentResolution.height - Screen.currentResolution.height / 10;
        int xGravity = Appodeal.BANNER_HORIZONTAL_CENTER;

        if (Appodeal.canShow(Appodeal.MREC) && !Appodeal.isPrecache(Appodeal.MREC))
        {
            Appodeal.showMrecView(yAxis, xGravity, "default");
            Debug.Log("Mrecshow");
        }
    }

    public void HideMrec()
    {
        Appodeal.hideMrecView();
    }

    public void ShowBanner()
    {
        Appodeal.show(Appodeal.BANNER_TOP);
        Debug.Log("Bannershow");
    }

    public void HideBanner()
    {
        Appodeal.hide(Appodeal.BANNER_TOP);
        Debug.Log("Bannerclosed");
    }


    public void onBannerClicked()
    {
        throw new System.NotImplementedException();
    }

    public void onBannerExpired()
    {
        throw new System.NotImplementedException();
    }

    public void onBannerFailedToLoad()
    {
        throw new System.NotImplementedException();
    }

    public void onBannerLoaded(int height, bool isPrecache)
    {
        throw new System.NotImplementedException();
    }

    public void onBannerShown()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialClicked()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialClosed()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialExpired()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialFailedToLoad()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialLoaded(bool isPrecache)
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialShowFailed()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialShown()
    {
        throw new System.NotImplementedException();
    }

    public void onMrecClicked()
    {
        throw new System.NotImplementedException();
    }

    public void onMrecExpired()
    {
        throw new System.NotImplementedException();
    }

    public void onMrecFailedToLoad()
    {
        throw new System.NotImplementedException();
    }

    public void onMrecLoaded(bool isPrecache)
    {
        throw new System.NotImplementedException();
    }

    public void onMrecShown()
    {
        throw new System.NotImplementedException();
    }
}
