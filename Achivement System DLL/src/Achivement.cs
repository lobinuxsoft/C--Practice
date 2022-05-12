using System;

namespace AchivementSystemDLL
{
    class Achivement
    {
        AchivementData data;

        public uint Count
        {
            get => data.Count;
            set
            {
                data.Count = value;
                if (data.Count == data.AmountToUnlock) onAchivementUnlock?.Invoke(data);
            }
        }

        public AchivementData Data => data;

        public bool IsUnlocked => data.IsUnlocked;

        public event Action<AchivementData> onAchivementUnlock;

        public Achivement(AchivementData data) => this.data = data;
    }
}