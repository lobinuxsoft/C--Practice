using System;
using Game.Structs;

namespace Game.Class.Objects
{
    class Entity
    {
        protected Random random;
        ConsoleColor color = ConsoleColor.White;

        private Vector2 position;
        private Vector2 screenMargin = Vector2.One;
        private char graph;

        public Vector2 Position
        {
            get => position;
            set 
            {
                Console.SetCursorPosition(position.x, position.y);
                Console.WriteLine(' ');
                position = value;
                if (position.x < screenMargin.x) position.x = screenMargin.x;
                else if (position.x > Console.WindowWidth - screenMargin.x) position.x = Console.WindowWidth - screenMargin.x;
                else if (position.y < screenMargin.y) position.y = screenMargin.y;
                else if (position.y > Console.WindowHeight - screenMargin.y) position.y = Console.WindowHeight - screenMargin.y;
            }
        }

        public Vector2 ScreenMargin
        {
            get => screenMargin;
            set => screenMargin = value;
        }

        public char Graph
        {
            get => graph;
            set => graph = value;
        }

        public ConsoleColor Color
        {
            get => color;
            set => color = value;
        }

        public Entity(char graph) : this(graph, Vector2.Zero) { }

        public Entity(char graph, Vector2 position)
        {
            random = new Random(DateTime.Now.Millisecond);
            this.graph = graph;
            this.position = position;
        }

        public void SetRandomPos()
        {
            Vector2 pos = new Vector2(random.Next(0, Console.WindowWidth), random.Next(0, Console.WindowHeight));
            Position = pos;
        }

        public virtual void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(position.x, position.y);
            Console.WriteLine(graph);
        }
    }
}
