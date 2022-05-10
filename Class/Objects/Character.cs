using Game.Structs;

namespace Game.Class.Objects
{
    class Character : Entity
    {
        private int maxHealth = 10;
        private int health = 0;

        public int MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        public int Health
        { 
            get => health;
            set 
            {
                health = value;

                if (health < 0)
                    health = 0;
                else if (health > maxHealth)
                    health = maxHealth;
            }
        }

        public Character(char graph, int maxHealth = 10) : this(graph, Vector2.Zero, maxHealth) { }

        public Character(char graph, Vector2 position, int maxHealth = 10) : base(graph, position)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        public void Move(Vector2 newPosition)=> Position += newPosition;
    }
}