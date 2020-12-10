using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class LoadCoins : MonoBehaviour
    {
        private PlayerData _playerData;

        void Start()
        {
            _playerData = SaveSystem.LoadPlayerData();
            var coinsAmount = GetComponent<Text>();
            coinsAmount.text = _playerData.Coins.ToString();
        }

    }
}
