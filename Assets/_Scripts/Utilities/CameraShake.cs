using UnityEngine;

namespace _Scripts.Utilities
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] [Range(0.0f, 1.0f)]
        private float shakeAmount = 0.7f;
        [SerializeField] [Range(0.0f, 1.0f)]
        private float decreaseFactor = 1.0f;

        private float _shakeDuration;
        private Vector3 _originalPos;
        private Transform _camTransform;
	
        void Awake()
        {
            _shakeDuration = 0f;
            if (_camTransform == null)
            {
                _camTransform = GetComponent(typeof(Transform)) as Transform;
            }
        }
	
        void OnEnable()
        {
            _originalPos = _camTransform.localPosition;
        }

        void Update()
        {
            if (_shakeDuration > 0)
            {
                _camTransform.localPosition = _originalPos + Random.insideUnitSphere * shakeAmount;
			
                _shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                _shakeDuration = 0f;
                _camTransform.localPosition = _originalPos;
            }
        }
    }
}