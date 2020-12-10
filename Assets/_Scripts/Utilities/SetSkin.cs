using UnityEngine;

namespace _Scripts.Utilities
{
    public class SetSkin : MonoBehaviour
    {
        public GameObject BoboSkin;
        public GameObject EggySkin;
        public GameObject KiwiSkin;
        public GameObject LangsatSkin;
        
        void Start()
        {
            var skinToSpawn = GetSkin();
            Instantiate(skinToSpawn, gameObject.transform);
        }

        private GameObject GetSkin()
        {
            var playerData = SaveSystem.LoadPlayerData();

            switch (playerData.PickedSkin)
            {
                case 1:
                    return EggySkin;
                case 2:
                    return KiwiSkin;
                case 3:
                    return LangsatSkin;
                default:
                    return BoboSkin;
            }
        }
    }
}
