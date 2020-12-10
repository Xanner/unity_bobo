using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts
{
    [RequireComponent(typeof(Button))]
    public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener
    {
        #if UNITY_IOS
            private string gameId = "3857829";
        #elif UNITY_ANDROID
                private string gameId = "3857829";
        #endif

        private Button _myButton;
        public string myPlacementId = "LifeRestoration";

        void Start()
        {
            _myButton = GetComponent<Button>();

            _myButton.interactable = Advertisement.IsReady(myPlacementId);

            if (_myButton)
                _myButton.onClick.AddListener(ShowRewardedVideo);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, false);
        }

        void ShowRewardedVideo()
        {
            Advertisement.Show(myPlacementId);
        }

        public void OnUnityAdsReady(string placementId)
        {
            if (placementId == myPlacementId)
            {
                _myButton.interactable = true;
            }
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (showResult == ShowResult.Finished)
            {
                LevelManager.Instance.OnGoingGame();
            }
            else if (showResult == ShowResult.Skipped)
            {
                LevelManager.Instance.RestartLevel();
            }
            else if (showResult == ShowResult.Failed)
            {
                Debug.LogWarning("The ad did not finish due to an error.");
            }
        }

        public void OnUnityAdsDidError(string message)
        {
            LevelManager.Instance.RestartLevel();
            // Log the error.
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            // Optional actions to take when the end-users triggers an ad.
        }
    }
}