namespace AchivementSystemDLL
{
    public struct AchivementData
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsUnlocked => Count >= AmountToUnlock;

        public uint AmountToUnlock { get; set; }

        public uint Count { get; set; }
    }
}