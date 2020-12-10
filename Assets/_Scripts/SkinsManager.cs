using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class SkinsManager : MonoBehaviour
    {
        public GameObject skinSelectedText;
        
        public void OnBoboSkinSelect()
        {
            var playerData = SaveSystem.LoadPlayerData();
            playerData.PickedSkin = 0;
            SaveSystem.SavePlayerData(playerData);
            StartCoroutine(ShowSkinInfo());
        }
    
        public void OnEggySkinSelect()
        {
            TryBuySkin(1);
        }

        public void OnKiwiSkinSelect()
        {
            TryBuySkin(2);
        }
    
        public void OnLangsatSkinSelect()
        {
            TryBuySkin(3);
        }
        
        private void TryBuySkin(int skinIndex)
        {
            var playerData = SaveSystem.LoadPlayerData();
            var skin = playerData.Skins[skinIndex];
            if (playerData.Coins >= skin.Cost && skin.IsLocked)
            {
                playerData.Skins[skinIndex].IsLocked = false;
                playerData.Coins -= skin.Cost;
            }

            if (!skin.IsLocked)
            {
                playerData.PickedSkin = skinIndex;
                StartCoroutine(ShowSkinInfo());
            }

            SaveSystem.SavePlayerData(playerData);
        }

        IEnumerator ShowSkinInfo()
        {
            skinSelectedText.SetActive(true);
            yield return new WaitForSeconds(1f);
            skinSelectedText.SetActive(false);
        }
    }
}
