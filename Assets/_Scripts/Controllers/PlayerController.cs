using System.Collections;
using _Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject childrenToSpawn = null;
        [SerializeField] private GameObject visualChildrenToSpawn = null;
        [SerializeField] private float rotationSpeed = 10f;
        private bool _canShoot = true;
    
        void FixedUpdate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * rotationSpeed));
        }

        private void Start()
        {
            visualChildrenToSpawn.SetActive(true);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1") 
                && _canShoot
                && visualChildrenToSpawn.activeSelf 
                && !EventSystem.current.currentSelectedGameObject
                && !LevelManager.Instance.IsLevelFailed())
            {
                var localOffset = new Vector3(0,0,1f);
                var worldOffset = transform.rotation * localOffset;
                var spawnPosition = transform.position + worldOffset;

                Instantiate(childrenToSpawn, spawnPosition, transform.rotation);
                
                _canShoot = false;
                visualChildrenToSpawn.SetActive(false);
                StartCoroutine(LoadBullet());
            }
        }

        IEnumerator LoadBullet()
        {
            yield return new WaitForSeconds(0.1f);
            visualChildrenToSpawn.SetActive(true);
            _canShoot = true;
        }
    }
}
