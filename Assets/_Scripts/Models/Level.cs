using System;

namespace _Scripts.Models
{
    [Serializable]
    public class Level
    {
        public int Id { get; set; }
        public float TimeToThreeStarsSec { get; set; }
        public float TimeToTwoStarsSec { get; set; }
        public float LevelPassedTimeSec { get; set; }

        public Level(int id, float timeToThreeStarsSec, float timeToTwoStarsSec, float levelPassedTimeSec)
        {
            Id = id;
            TimeToThreeStarsSec = timeToThreeStarsSec;
            TimeToTwoStarsSec = timeToTwoStarsSec;
            LevelPassedTimeSec = levelPassedTimeSec;
        }
    }
}