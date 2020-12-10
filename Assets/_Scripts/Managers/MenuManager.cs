using _Scripts.Models;
using _Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject LevelsSelector;
        public GameObject Skins;
        public GameObject MuteButton; 
        public GameObject UnmuteButton;
        private PlayerData _playerData;
        private void Awake()
        {
            _playerData = SaveSystem.LoadPlayerData();
            if(_playerData == null)
                SaveSystem.InitializePlayerData();

            _playerData = SaveSystem.LoadPlayerData();

            var volume = PlayerPrefs.GetFloat("volume");
            if (volume == 0)
            {
                MuteButton.SetActive(false); 
                UnmuteButton.SetActive(true); 
            }
            else
            {
                MuteButton.SetActive(true); 
                UnmuteButton.SetActive(false); 
            }
        }

        public void OnExitSelect()
        {
            Application.Quit();
        }

        public void OnPlaySelect()
        {
            var scenePath = SceneUtility.GetScenePathByBuildIndex(_playerData.SelectedSceneIndex);
            SceneManager.LoadScene(scenePath);
        }

        public void OnMuteSelect()
        {
            MuteButton.SetActive(false);
            UnmuteButton.SetActive(true);
            PlayerPrefs.SetFloat("volume", 0);
            AudioListener.volume = 0;
        }       
        
        public void OnUnmuteSelect()
        {
            UnmuteButton.SetActive(false);
            MuteButton.SetActive(true);
            PlayerPrefs.SetFloat("volume", 1);
            AudioListener.volume = 1;
        }
        
        public void OnLevelsSelect()
        {
            LevelsSelector.SetActive(true);
        }
        
        public void OnSkinsSelect()
        {
            Skins.SetActive(true);
        }
        
        public void OnBackSelect()
        {
            LevelsSelector.SetActive(false);
            Skins.SetActive(false);
        }
    }
}
