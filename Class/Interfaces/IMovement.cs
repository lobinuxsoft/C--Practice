using Game.Structs;
using System;

namespace Game.Class.Interfaces
{
    public interface IMovement 
    {
        Vector2 Move(Vector2 position, Random rnd);
    }
}
