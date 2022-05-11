using System;

namespace Game.Class.Manager
{
    class Achivement
    {
        AchivementData achivementData;

        private uint amountToUnlock;

        private uint count;

        public uint Count 
        {
            get => count;
            set 
            {
                count = value;
                if (count == amountToUnlock) onAchivementUnlock?.Invoke(achivementData);
            }
        }

        public AchivementData Data => achivementData;

        public bool IsUnlocked => count >= amountToUnlock;

        public Action<AchivementData> onAchivementUnlock;

        public Achivement(AchivementData achivementData, uint amountToUnlock)
        {
            this.achivementData = achivementData;
            this.amountToUnlock = amountToUnlock;
        }
    }
}
