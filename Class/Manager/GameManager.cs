using Game.Class.Objects;
using System;

namespace Game.Class.Manager
{

    class GameManager
    {
        private bool isPlaying = true;
        private Player player;

        private Enemy enemy;

        public void Run()
        {
            Console.CursorVisible = false;

            player = new Player('O', new Vector2(Console.WindowWidth / 2, Console.WindowHeight / 2));
            enemy = new Enemy('E', new Vector2(1, 1));
            
            

            while (isPlaying)
            {
                player.Update();
                player.Draw();

                enemy.Update();
                enemy.Draw();
            }
        }
    }
}