﻿using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class TryAgainButton : MonoBehaviour
    {
        private Button _myButton;

        void Start()
        {
            _myButton = GetComponent<Button>();

            if (_myButton)
                _myButton.onClick.AddListener(LevelManager.Instance.RestartLevel);
        }
    }
}