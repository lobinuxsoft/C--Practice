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
                player.Update();

                player.Draw();
            }
        }
    }
}