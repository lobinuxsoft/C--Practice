namespace Game.Class
{
    struct Vector2
    {
        public int x;
        public int y;

        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);
        public static Vector2 Left => new Vector2(-1, 0);
        public static Vector2 Up => new Vector2(0, 1);
        public static Vector2 Right => new Vector2(1, 0);
        public static Vector2 Down => new Vector2(0, -1);

        public Vector2(int x, int y) { this.x = x; this.y = y; }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            lhs.x += rhs.x;
            lhs.y += rhs.y;
            return lhs;
        }
    }
}
