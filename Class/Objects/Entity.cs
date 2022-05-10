using System;

namespace Game.Class.Objects
{
    class Entity
    {
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

        public Entity(char graph)
        {
            this.graph = graph;
            position = new Vector2(0, 0);
        }
        public Entity(char graph, Vector2 position)
        {
            this.graph = graph;
            this.position = position;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.WriteLine(graph);
        }
    }
}
