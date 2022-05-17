using System;
using Game.Class.Interfaces;
using Game.Structs;

namespace Game.Class.Objects
{
    partial class Enemy : Character
    {
        IMovement movement;

        long lastTimeMove = 0;

        public Enemy(char graph, IMovement movement, int maxHealth = 10) : base(graph, maxHealth) 
        {
            this.movement = movement;
        }

        public Enemy(char graph, Vector2 position, IMovement movement, int maxHealth = 10) : base(graph, position, maxHealth) 
        { 
            this.movement = movement;
        }

        public override void Draw()
        {
            if (DateTime.Now.Ticks - lastTimeMove > 5000000)
            {
                Move(movement.Move(Position, random));
                lastTimeMove = DateTime.Now.Ticks;
            }

            base.Draw();
        }
    }
}
