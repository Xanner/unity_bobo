using System;
using _Scripts.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Utilities
{
    public class LevelsButtonGenerator : MonoBehaviour
    {
        public Button buttonPrefab;
        private PlayerData _playerData;
        
        void Awake()
        {
            var scenesCount = SceneManager.sceneCountInBuildSettings;
            _playerData = SaveSystem.LoadPlayerData();
            
            for (int i = 1; i < scenesCount; i++)
            {
                var button = Instantiate(buttonPrefab, transform, true);
                var sceneBuildIndex = i;
                
                ConfigureButton(i, _playerData, button, sceneBuildIndex);
            }
        }

        private void ConfigureButton(int i, PlayerData playerData, Button button, int sceneBuildIndex)
        {
            if (i > playerData.ReachedSceneIndex + 1)
            {
                button.interactable = false;
            }
            else
            {
                var stars = button.GetComponentsInChildren<Image>();
                var levelData = playerData.Levels[i - 1];
                if (levelData.LevelPassedTimeSec > 0)
                {
                    stars[1].rectTransform.localScale = new Vector3(1,1,1);

                    if (levelData.LevelPassedTimeSec < levelData.TimeToTwoStarsSec)
                        stars[2].rectTransform.localScale = new Vector3(1,1,1);
                    
                    if (levelData.LevelPassedTimeSec < levelData.TimeToThreeStarsSec)
                        stars[3].rectTransform.localScale = new Vector3(1,1,1);
                }

                button.onClick.AddListener(() => LoadLevel(sceneBuildIndex));
            }

            var buttonText = button.GetComponentInChildren<Text>();
            buttonText.text = Convert.ToString(i);

            if (playerData?.SelectedSceneIndex == i)
            {
                var colorBlock = button.colors;
                colorBlock.normalColor = new Color(216/255f, 77/255f, 73/255f, 1.0f);
                button.colors = colorBlock;
            }
        }

        private void LoadLevel(int sceneBuildIndex)
        {
            var path = SceneUtility.GetScenePathByBuildIndex(sceneBuildIndex);
            _playerData.SelectedSceneIndex = sceneBuildIndex;
            SaveSystem.SavePlayerData(_playerData);
            SceneManager.LoadScene(path);
        }
    }
}
