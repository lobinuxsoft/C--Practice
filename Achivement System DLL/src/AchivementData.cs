namespace AchivementSystemDLL
{
    public struct AchivementData
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsUnlocked => Count >= AmountToUnlock;

        public uint AmountToUnlock { get; set; }

        public uint Count { get; set; }

        public AchivementData(string name, string description, uint amountToUnlock)
        {
            Name = name;
            Description = description;
            AmountToUnlock = amountToUnlock;
            Count = 0;
        }
    }
}