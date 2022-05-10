using System;

namespace Game.Class.Objects
{
    class Player : Character
    {
        Random random;

        public Player(char graph, int maxHealth) : base(graph, maxHealth) 
        {
            random = new Random(DateTime.Now.Millisecond);
        }

        public Player(char graph, Vector2 position, int maxHealth) : base(graph, position, maxHealth) 
        {
            random = new Random(DateTime.Now.Millisecond);
        }

        public void SetRandomPos()
        {
            Vector2 pos = new Vector2(random.Next(0, Console.WindowWidth), random.Next(0, Console.WindowHeight));
            Position = pos;
        }
    }
}
