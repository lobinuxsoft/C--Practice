using Game.Class.Objects;
using System;

namespace Game.Class.Manager
{

    class GameManager
    {
        private bool isPlaying = true;
        private Player player;

        public void Run()
        {
            Console.CursorVisible = false;

            player = new Player('O', new Vector2(Console.WindowWidth / 2, Console.WindowHeight / 2));
            

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    player.Move(Input(Console.ReadKey(true).KeyChar));
                }

                player.Draw();
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