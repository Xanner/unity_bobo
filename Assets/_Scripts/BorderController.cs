﻿using System;
using UnityEngine;

namespace _Scripts
{
    public class BorderController : MonoBehaviour
    {
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.Find("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            Destroy(other.gameObject);
            LevelManager.Instance.EndGame();
        }
    }
}