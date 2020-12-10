using System;
using System.Collections.Generic;

namespace _Scripts.Models
{
    [Serializable]
    public class PlayerData
    {
        public int ReachedSceneIndex { get; set; }
        public int SelectedSceneIndex { get; set; }
        public int Coins { get; set; }
        public int PickedSkin { get; set; }
        public List<Level> Levels { get; set; }
        public List<Skin> Skins { get; set; }

        public PlayerData(int reachedSceneIndex, int selectedSceneIndex, int coins, int pickedSkin, List<Level> levels, List<Skin> skins)
        {
            ReachedSceneIndex = reachedSceneIndex;
            SelectedSceneIndex = selectedSceneIndex;
            Coins = coins;
            PickedSkin = pickedSkin;
            Levels = levels;
            Skins = skins;
        }
    }
}
