using System;

namespace Game.Class.Manager
{
    class Achivement
    {
        AchivementData achivementData;

        public uint Count 
        {
            get => achivementData.Count;
            set 
            {
                achivementData.Count = value;
                if (achivementData.Count == achivementData.AmountToUnlock) onAchivementUnlock?.Invoke(achivementData);
            }
        }

        public AchivementData Data => achivementData;

        public bool IsUnlocked => achivementData.IsUnlocked;

        public Action<AchivementData> onAchivementUnlock;

        public Achivement(AchivementData achivementData) => this.achivementData = achivementData;
    }
}
