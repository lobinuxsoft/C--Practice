using Game.Class.Objects;
using System;

namespace Game.Class.Manager
{

    class GameManager
    {
        int score = 0;
        private bool isPlaying = true;
        private Player player;

        private Enemy enemy;

        public void Run()
        {
            Console.CursorVisible = false;

            player = new Player('O', new Vector2(Console.WindowWidth / 2, Console.WindowHeight / 2), 5);
            player.ScreenMargin = new Vector2(2, 2);

            enemy = new Enemy('E', new Vector2(1, 1));
            enemy.ScreenMargin = new Vector2(2, 2);



            while (isPlaying)
            {
                DrawHealthAndScore(player.Health, player.MaxHealth);

                player.Update();
                player.Draw();

                enemy.Update();
                enemy.Draw();
            }
        }

        void DrawHealthAndScore(int min, int max)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Healt: {min}/{max} --- Score: {score}");
        }
    }
}