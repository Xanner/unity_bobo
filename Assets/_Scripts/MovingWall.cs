using UnityEngine;

namespace _Scripts
{
    public class MovingWall : MonoBehaviour
    {
        [SerializeField] private float speed = 0.1f;
        [SerializeField] private float LeftBoundary = -2.5f;
        [SerializeField] private float RightBoundary = 2.5f;
        private Vector3 _direction = Vector3.right;

        void Update()
        {
            if (transform.position.x <= LeftBoundary)
            {
                _direction = Vector3.right;
            }
            else
            {
                if (transform.position.x >= RightBoundary)
                {
                    _direction = Vector3.left;
                }
            }

            transform.Translate(_direction * (speed * Time.deltaTime));
        }
    }
}
