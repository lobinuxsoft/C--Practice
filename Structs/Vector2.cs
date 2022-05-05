﻿namespace Game.Class
{
    struct Vector2
    {
        public int x;
        public int y;

        public static Vector2 Zero => new Vector2(0, 0);

        public Vector2(int x, int y) { this.x = x; this.y = y; }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            lhs.x += rhs.x;
            lhs.y += rhs.y;
            return lhs;
        }
    }
}
