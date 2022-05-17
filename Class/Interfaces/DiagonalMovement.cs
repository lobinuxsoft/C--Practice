using Game.Enums;
using Game.Structs;
using System;

namespace Game.Class.Interfaces
{
    public class DiagonalMovement : IMovement
    {
        public Vector2 Move(Vector2 position, Random rnd)
        {
            Vector2 result = Vector2.Zero;

            MoveDiagonalDirType movDirection = (MoveDiagonalDirType)rnd.Next((int)MoveDiagonalDirType.NONE, (int)(MoveDiagonalDirType.RIGHTDOWN) + 1);

            switch (movDirection)
            {
                case MoveDiagonalDirType.LEFTUP:
                    result = Vector2.Left + Vector2.Down;
                    break;
                case MoveDiagonalDirType.RIGHTUP:
                    result = Vector2.Right + Vector2.Down;
                    break;
                case MoveDiagonalDirType.LEFTDOWN:
                    result = Vector2.Left + Vector2.Up;
                    break;
                case MoveDiagonalDirType.RIGHTDOWN:
                    result = Vector2.Right + Vector2.Up;
                    break;
            }

            return result;
        }
    }
}
