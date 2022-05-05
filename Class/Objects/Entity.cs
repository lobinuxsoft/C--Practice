using System;

namespace Game.Class.Objects
{
    class Entity
    {
        private Vector2 position;
        private char graph;

        public Vector2 Position
        {
            get => position;
            set 
            {
                Console.SetCursorPosition(position.x, position.y);
                Console.WriteLine(' ');
                position = value;
                if (position.x < 0) position.x = 0;
                else if (position.x > Console.WindowWidth-1) position.x = Console.WindowWidth-1;
                else if (position.y < 0) position.y = 0;
                else if (position.y > Console.WindowHeight-1) position.y = Console.WindowHeight-1;
            }
        }

        public char Graph
        {
            get => graph;
            set => graph = value;
        }

        public Entity()
        {
            position = new Vector2(0, 0);
        }

        public void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.WriteLine(graph);
        }
    }
}
