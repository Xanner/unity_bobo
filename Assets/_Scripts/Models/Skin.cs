using System;

namespace _Scripts.Models
{
    [Serializable]
    public class Skin
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public bool IsLocked { get; set; }

        public Skin(int id, int cost, bool isLocked)
        {
            Id = id;
            Cost = cost;
            IsLocked = isLocked;
        }
    }
}