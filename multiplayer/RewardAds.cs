using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardAds : MonoBehaviour,IUnityAdsListener
{

    string placement = "rewardedVideo";
    
    void Start()
    {
        Advertisement.Initialize("3938179", true);
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        
        if(showResult == ShowResult.Finished)
        {

        }
    }
}
