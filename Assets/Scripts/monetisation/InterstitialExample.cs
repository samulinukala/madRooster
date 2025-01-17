using System;
using UnityEngine;
using Unity.Services.Core;
using System.Threading.Tasks;

namespace Unity.Services.Mediation.Samples
{
    /// <summary>
    /// Sample Implementation of Unity Mediation
    /// </summary>
    
    public class InterstitialExample : MonoBehaviour
    {
        [Header("Ad Unit Ids"), Tooltip("Android Ad Unit Ids")]
        public string androidAdUnitId;

        [Tooltip("iOS Ad Unit Ids")]
        public string iosAdUnitId;

        [Header("Game Ids"),
         Tooltip("[Optional] Specifies the iOS GameId. Otherwise uses the GameId of the linked project.")]
        public string iosGameId;

        [Tooltip("[Optional] Specifies the Android GameId. Otherwise uses the GameId of the linked project.")]
        public string androidGameId;

        IInterstitialAd m_InterstitialAd;

        public monetisationData monetisationData;
        

        async void Start()
        {
            try
            {
                Debug.Log("Initializing...");
                await UnityServices.InitializeAsync(GetGameId());
                Debug.Log("Initialized!");

                InitializationComplete();
            }
            catch (Exception e)
            {
                InitializationFailed(e);
            }
        }

        void OnDestroy()
        {
            m_InterstitialAd?.Dispose();
        }
        
        InitializationOptions GetGameId()
        {
            var initializationOptions = new InitializationOptions();

#if UNITY_IOS
            if (!string.IsNullOrEmpty(iosGameId))
            {
                initializationOptions.SetGameId(iosGameId);
            }
#elif UNITY_ANDROID
            if (!string.IsNullOrEmpty(androidGameId))
            {
                initializationOptions.SetGameId(androidGameId);
            }
#endif
            return initializationOptions;
        }

        public async void ShowInterstitial()
        {
            if (monetisationData.hasPurchasedContent == false && monetisationData.WhenToShowAds >= monetisationData.ammountOfTimesSinceAds)
            {
                if (m_InterstitialAd?.AdState == AdState.Loaded)
                {
                    try
                    {
                        var showOptions = new InterstitialAdShowOptions { AutoReload = true };
                        await m_InterstitialAd.ShowAsync(showOptions);
                        Debug.Log("Interstitial Shown!");
                    }
                    catch (ShowFailedException e)
                    {
                        Debug.Log($"Interstitial failed to show : {e.Message}");
                    }
                }
                //monetisationData.ammountOfTimesSinceAds = 0;
            }
            else if (monetisationData.hasPurchasedContent == true)
            { 
                Debug.Log("No ad shown, IAP has been bought."); 
            }
            else Debug.Log("No ad shown yet");
        }

        async void LoadAd()
        {
            try
            {
                await m_InterstitialAd.LoadAsync();
            }
            catch (LoadFailedException)
            {
                // We will handle the failure in the OnFailedLoad callback
            }
        }

        void InitializationComplete()
        {
            
                // Impression Event
                MediationService.Instance.ImpressionEventPublisher.OnImpression += ImpressionEvent;

                switch (Application.platform)
                {
                    case RuntimePlatform.Android:
                        m_InterstitialAd = MediationService.Instance.CreateInterstitialAd(androidAdUnitId);
                        Debug.Log("Loaded IntAd!!!");
                        break;

                    case RuntimePlatform.IPhonePlayer:
                        m_InterstitialAd = MediationService.Instance.CreateInterstitialAd(iosAdUnitId);
                        break;
                    case RuntimePlatform.WindowsEditor:
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.LinuxEditor:
                        m_InterstitialAd = MediationService.Instance.CreateInterstitialAd(!string.IsNullOrEmpty(androidAdUnitId) ? androidAdUnitId : iosAdUnitId);
                        break;
                    default:
                        Debug.LogWarning("Mediation service is not available for this platform:" + Application.platform);
                        return;
                }

                // Load Events
                m_InterstitialAd.OnLoaded += AdLoaded;
                m_InterstitialAd.OnFailedLoad += AdFailedLoad;

                // Show Events
                m_InterstitialAd.OnClosed += AdClosed;                

                Debug.Log("Initialized On Start! Loading Ad...");
                LoadAd();            
        }

        void InitializationFailed(Exception error)
        {
            SdkInitializationError initializationError = SdkInitializationError.Unknown;
            if (error is InitializeFailedException initializeFailedException)
            {
                initializationError = initializeFailedException.initializationError;
            }
            Debug.Log($"Initialization Failed: {initializationError}:{error.Message}");
        }

        void AdClosed(object sender, EventArgs args)
        {
            Debug.Log("Interstitial Closed! Loading Ad...");
        }

        void AdLoaded(object sender, EventArgs e)
        {
            Debug.Log("Ad loaded");
        }

        void AdFailedLoad(object sender, LoadErrorEventArgs e)
        {
            Debug.Log("Failed to load ad");
            Debug.Log(e.Message);
        }

        void ImpressionEvent(object sender, ImpressionEventArgs args)
        {
            var impressionData = args.ImpressionData != null ? JsonUtility.ToJson(args.ImpressionData, true) : "null";
            Debug.Log($"Impression event from ad unit id {args.AdUnitId} : {impressionData}");
        }
    }
}
