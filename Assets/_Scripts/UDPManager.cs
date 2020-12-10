using UnityEngine;
using UnityEngine.UDP;

namespace _Scripts
{
    public class UDPManager : MonoBehaviour, IInitListener
    {
        void Start()
        {
            StoreService.Initialize(this);
        }

        public void OnInitialized(UserInfo userInfo)
        {
            Debug.Log(userInfo);
        }

        public void OnInitializeFailed(string message)
        {
            Debug.Log(message);
        }
    }
}
