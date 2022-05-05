using Game.Class.Objects;
using System;
using System.Threading;

namespace Game.Class.Manager
{

    class GameManager
    {
        private bool isPlaying = true;
        private Entity entity;

        public void Run()
        {
            entity = new Entity();
            entity.Graph = 'X';

            while (isPlaying)
            {
                //Console.Clear();
                entity.Position += Input(Console.ReadKey(true).KeyChar);
                entity.Draw();
                //Thread.Sleep(200);
            }
        }

        private Vector2 Input(char input)
        {
            Vector2 result = Vector2.Zero;
            switch (input)
            {
                case 'a':
                    result.x = -1;
                    result.y = 0;
                    break;
                case 'd':
                    result.x = 1;
                    result.y = 0;
                    break;
                case 'w':
                    result.x = 0;
                    result.y = -1;
                    break;
                case 's':
                    result.x = 0;
                    result.y = 1;
                    break;
            }
            return result;
        }
    }
}
