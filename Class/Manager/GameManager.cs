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

                if (Console.KeyAvailable)
                {
                    player.Move(Input(Console.ReadKey(true).KeyChar));
                }

                player.Draw();

                enemy.Draw();

                if(player.Position == enemy.Position)
                {
                    player.Health--;
                    player.SetRandomPos();
                }
            }
        }

        void DrawHealthAndScore(int min, int max)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Healt: {min}/{max} --- Score: {score}");
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