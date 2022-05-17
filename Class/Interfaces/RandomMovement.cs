using Game.Enums;
using Game.Structs;
using System;

namespace Game.Class.Interfaces
{
    public class RandomMovement : IMovement
    {
        public Vector2 Move(Vector2 position, Random rnd)
        {
            Vector2 result = Vector2.Zero;

            MoveCrossDirType movDirection = (MoveCrossDirType)rnd.Next((int)MoveCrossDirType.NONE, (int)(MoveCrossDirType.DOWN) + 1);

            switch (movDirection)
            {
                case MoveCrossDirType.LEFT:
                    result = Vector2.Left;
                    break;
                case MoveCrossDirType.UP:
                    result = Vector2.Down;
                    break;
                case MoveCrossDirType.RIGHT:
                    result = Vector2.Right;
                    break;
                case MoveCrossDirType.DOWN:
                    result = Vector2.Up;
                    break;
            }

            return result;
        }
    }
}
