using UnityEngine;

namespace _Scripts.Utilities
{
    public class MoveUpAndDown : MonoBehaviour
    {
        [SerializeField] private float speed = 0.1f;
        [SerializeField] private float TopBoundary = 2f;
        [SerializeField] private float BottomBoundary = -2f;
        private Vector3 _direction = Vector3.forward;

        void Update()
        {
            if (transform.position.z >= TopBoundary)
            {
                _direction = Vector3.back;
            }
            else
            {
                if (transform.position.z <= BottomBoundary)
                {
                    _direction = Vector3.forward;
                }
            }

            transform.Translate(_direction * (speed * Time.deltaTime));
        }
    }
}
