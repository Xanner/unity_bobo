using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class Timer : MonoBehaviour
    {
        private Text _timerText;
        private float _time;
        
        void Start()
        {
            _timerText = GetComponent<Text>();
        }
        
        void Update()
        {
            if (!LevelManager.Instance.IsLevelComplete() && !LevelManager.Instance.IsLevelFailed())
            {
                _time += Time.deltaTime;
                _timerText.text = String.Format("{0:0.0}", _time); 
            }
        }
    }
}
