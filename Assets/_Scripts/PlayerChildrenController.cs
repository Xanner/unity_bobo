using UnityEngine;

namespace _Scripts
{
    public class PlayerChildrenController : MonoBehaviour
    {
        private Rigidbody _rb;
        [SerializeField] private float throwForce = 12f;
        [SerializeField] private AudioSource launchSound = null;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.AddRelativeForce(Vector3.forward * throwForce, ForceMode.Impulse);
            launchSound.Play();
        }
    }
}
