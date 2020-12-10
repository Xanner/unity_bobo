using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace _Scripts.Utilities.Ads
{
    public class BannerAd : MonoBehaviour {

        #if UNITY_IOS
            private string gameId = "3857829";
        #elif UNITY_ANDROID
                private string gameId = "3857829";
        #endif
        public string placementId = "BoboBanner";
        public bool testMode = false;

        void Start () {
            Advertisement.Initialize(gameId, testMode);
            StartCoroutine(ShowBannerWhenInitialized());
        }

        IEnumerator ShowBannerWhenInitialized () {
            while (!Advertisement.isInitialized) {
                yield return new WaitForSeconds(0.5f);
            }
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(placementId);
        }
    }
}