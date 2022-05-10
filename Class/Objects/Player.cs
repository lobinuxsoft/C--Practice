using Game.Structs;

namespace Game.Class.Objects
{
    class Player : Character
    {
        private bool isAttack = false;

        public bool IsAttack
        {
            get => isAttack;
            set => isAttack = value;
        }

        public Player(char graph, int maxHealth) : base(graph, maxHealth) { }

        public Player(char graph, Vector2 position, int maxHealth) : base(graph, position, maxHealth) { }
    }
}
