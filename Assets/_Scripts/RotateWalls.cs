﻿using UnityEngine;

namespace _Scripts
{
    public class RotateWalls : MonoBehaviour
    {
        [SerializeField] private float rotationSped = 100f;

        void Update()
        {
            transform.Rotate(Time.deltaTime * rotationSped * Vector3.down);
        }
    }
}
