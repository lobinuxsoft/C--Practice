using System;
using System.Diagnostics;

namespace Game.Class.Objects
{
    class Enemy : Character
    {
        enum MovDirection { NONE, LEFT, UP, RIGHT, DOWN }

        long lastTimeMove = 0;

        Random random;

        public Enemy(char graph, int maxHealth = 10) : base(graph, maxHealth) 
        {
            random = new Random(DateTime.Now.Millisecond);
        }

        public Enemy(char graph, Vector2 position, int maxHealth = 10) : base(graph, position, maxHealth) 
        {
            random = new Random(DateTime.Now.Millisecond);
        }

        public override void Draw()
        {
            if (DateTime.Now.Ticks - lastTimeMove > 1000000)
            {
                Move(IaCalculationMove());
                lastTimeMove = DateTime.Now.Ticks;
            }

            base.Draw();
        }

        private Vector2 IaCalculationMove()
        {
            Vector2 result = Vector2.Zero;

            


            MovDirection movDirection = (MovDirection)random.Next((int)MovDirection.NONE, (int)(MovDirection.DOWN) + 1);

            switch (movDirection)
            {
                case MovDirection.LEFT:
                    result = Vector2.Left;
                    break;
                case MovDirection.UP:
                    result = Vector2.Down;
                    break;
                case MovDirection.RIGHT:
                    result = Vector2.Right;
                    break;
                case MovDirection.DOWN:
                    result = Vector2.Up;
                    break;
            }

            return result;
        }
    }
}
