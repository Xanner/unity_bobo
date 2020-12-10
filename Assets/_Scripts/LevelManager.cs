using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts
{
    public sealed class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance => _instance;
        private static LevelManager _instance;
        public PlayerData PlayerData { get; set; }
        
        private bool _isFailed;
        private bool _isLevelComplete;
        private GameObject _levelCompleteScreen;
        private GameObject _gameOverScreen;
        private GameObject[] _walls;
        private int _wallsCount;
        
        [SerializeField] private Text coinText;
        [SerializeField] private GameObject[] starsImg;

        private void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(gameObject);
            else
                _instance = this;
        }

        private void Start()
        {
            GetPlayerData();
            InitializeScene();
        }

        private void GetPlayerData()
        {
            PlayerData = SaveSystem.LoadPlayerData();
            if (PlayerData != null) return;
            
            SaveSystem.InitializePlayerData();
            PlayerData = SaveSystem.LoadPlayerData();
        }
        
        private void InitializeScene()
        {
            _walls = GameObject.FindGameObjectsWithTag("Wall");
            _levelCompleteScreen = GameObject.FindGameObjectWithTag("LevelComplete");
            _gameOverScreen = GameObject.FindGameObjectWithTag("LevelFailed");

            _wallsCount = _walls.Length;
            _levelCompleteScreen.SetActive(false);
            _gameOverScreen.SetActive(false);
        }

        public bool IsLevelFailed()
        {
            return _isFailed;
        }
        
        public bool IsLevelComplete()
        {
            return _isLevelComplete;
        }

        public void DecreaseWallCount()
        {
            _wallsCount--;
        }

        public void EndGame()
        {
            if (_isLevelComplete) return;
            _isFailed = true;
            _gameOverScreen.SetActive(true);
        }

        public void OnGoingGame()
        {
            _isFailed = false;
            _gameOverScreen.SetActive(false);
        }

        public void RestartLevel()
        {
            _isFailed = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OnMenuLoadSelect()
        {
            Advertisement.Banner.Hide();
            SceneManager.LoadScene("Menu");
        }

        private void Update()
        {
            if (_wallsCount == 0 && !_isLevelComplete)
            {
                CompleteLevel();
            }
        }

        private void CompleteLevel()
        {
            _isLevelComplete = true;
            SaveCompletedLevel();
            _levelCompleteScreen.gameObject.SetActive(true);
            StartCoroutine(nameof(LoadNextScene));
        }

        private void SaveCompletedLevel()
        {
            if (PlayerData == null) return;

            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SetPlayerDataScene(currentSceneIndex);

            var timer = GameObject.FindWithTag("Timer").GetComponent<Text>().text;
            var parsedTimer = float.Parse(timer);
            var currentLevelData = PlayerData.Levels[currentSceneIndex - 1];
            var stars = 1;
            
            stars = CalculateStars(parsedTimer, currentLevelData, stars);
            
            AddCoins(parsedTimer, currentSceneIndex, stars);
            SaveSystem.SavePlayerData(PlayerData);
        }

        private int CalculateStars(float parsedTimer, Level currentLevelData, int stars)
        {
            if (parsedTimer < currentLevelData.LevelPassedTimeSec || currentLevelData.LevelPassedTimeSec == 0)
            {
                currentLevelData.LevelPassedTimeSec = parsedTimer;

                if (currentLevelData.LevelPassedTimeSec < currentLevelData.TimeToTwoStarsSec)
                    stars++;

                if (currentLevelData.LevelPassedTimeSec < currentLevelData.TimeToThreeStarsSec)
                    stars++;

                SetActiveStars(stars);
            }

            return stars;
        }

        private void SetActiveStars(int stars)
        {
            starsImg[0].SetActive(true);
            
            if (stars >= 2)
                starsImg[1].SetActive(true);
            
            if (stars >= 3)
                starsImg[2].SetActive(true);
        }

        private void SetPlayerDataScene(int currentSceneIndex)
        {
            if (PlayerData.ReachedSceneIndex < currentSceneIndex)
            {
                PlayerData.ReachedSceneIndex = currentSceneIndex;
            }

            var scenesCount = SceneManager.sceneCountInBuildSettings;

            if (scenesCount - 1 == currentSceneIndex)
            {
                PlayerData.SelectedSceneIndex = currentSceneIndex;
            }
            else
            {
                PlayerData.SelectedSceneIndex = currentSceneIndex + 1;
            }
        }

        private void AddCoins(float passedTime, int levelIndex, int stars)
        {
            var earnedCoins = (30 - (int)passedTime) + levelIndex * 5 * stars;
            PlayerData.Coins += earnedCoins;
            coinText.text = earnedCoins.ToString();
        }

        private IEnumerator LoadNextScene()
        {
            if ((SceneManager.sceneCountInBuildSettings - 1) == SceneManager.GetActiveScene().buildIndex)
            {
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene("Menu");
            }
            else
            {
                var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                var path = SceneUtility.GetScenePathByBuildIndex(++currentSceneIndex);
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene(path);
            }
        }
    }
}