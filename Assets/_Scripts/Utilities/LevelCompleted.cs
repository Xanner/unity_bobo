using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Utilities
{
    public class LevelCompleted : MonoBehaviour
    {
        private Text _levelNumberText;
        
        void Start()
        {
            _levelNumberText = GetComponent<Text>();
            _levelNumberText.text = SceneManager.GetActiveScene().buildIndex.ToString();
        }
    }
}
