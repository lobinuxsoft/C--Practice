using System;

namespace Game.Class.Objects
{
    class Player : Character
    {
        public Player(char graph, int maxHealth) : base(graph, maxHealth) { }

        public Player(char graph, Vector2 position, int maxHealth) : base(graph, position, maxHealth) { }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                Move(Input(Console.ReadKey(true).KeyChar));
            }
        }

        private Vector2 Input(char input)
        {
            Vector2 result = Vector2.Zero;
            switch (input)
            {
                case 'a':
                    result.x = -1;
                    result.y = 0;
                    break;
                case 'd':
                    result.x = 1;
                    result.y = 0;
                    break;
                case 'w':
                    result.x = 0;
                    result.y = -1;
                    break;
                case 's':
                    result.x = 0;
                    result.y = 1;
                    break;
            }
            return result;
        }
    }
}
