using System.Collections;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Controllers
{
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPS = null;
        [SerializeField] private AudioSource hitSound = null;
        [SerializeField] private AudioClip explosionSound = null;
        [SerializeField] private float shrinkScale = 1.5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var hitEffect = Instantiate(explosionPS, other.transform.position, other.transform.rotation);
                hitSound.Play();
                StartCoroutine(ScaleObject());
                Destroy(other.gameObject);
                Destroy(hitEffect, 3f);
            }
        }

        private IEnumerator ScaleObject()
        {
            float scaleDuration = 0.5f;                              
            Vector3 actualScale = transform.localScale;             
            Vector3 targetScale = new Vector3 (actualScale.x - shrinkScale,actualScale.y,actualScale.z);     
      
            for(float t = 0; t < 1; t += Time.deltaTime / scaleDuration )
            {
                transform.localScale = Vector3.Lerp(actualScale ,targetScale ,t);
                if (transform.localScale.x < 1.5f)
                {
                    LevelManager.Instance.DecreaseWallCount();
                    AudioSource.PlayClipAtPoint(explosionSound, transform.position);
                    Destroy(gameObject);
                }
                yield return null;
            }
        }
    }
}
