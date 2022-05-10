using System;

namespace Game.Structs
{
    static class Input
    {
        public static Vector2 GetDirection(ConsoleKey key, ConsoleKey left = ConsoleKey.A, ConsoleKey right = ConsoleKey.D, ConsoleKey up = ConsoleKey.W, ConsoleKey down = ConsoleKey.S)
        {
            Vector2 direction = Vector2.Zero;

            if (key == left)
            {
                direction = Vector2.Left;
            }
            else if(key == right)
            {
                direction = Vector2.Right;
            }
            else if(key == up)
            {
                direction = Vector2.Down;
            }
            else if(key == down)
            {
                direction = Vector2.Up;
            }

            return direction;
        }
    }
}