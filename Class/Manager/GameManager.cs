using Game.Class.Objects;
using Game.Structs;
using System;

namespace Game.Class.Manager
{

    class GameManager
    {
        int score = 0;
        private bool isPlaying = true;

        private Player player1;
        private Player player2;

        private Enemy enemy;

        public void Run()
        {
            Console.CursorVisible = false;

            player1 = new Player('1', new Vector2(0, 0), 5);
            player1.ScreenMargin = new Vector2(2, 2);
            player1.SetRandomPos();

            player2 = new Player('2', new Vector2(0, 0), 5);
            player2.ScreenMargin = new Vector2(2, 2);
            player2.SetRandomPos();

            enemy = new Enemy('E', new Vector2(1, 1));
            enemy.ScreenMargin = new Vector2(2, 2);



            while (isPlaying)
            {
                DrawHealthAndScore(player1.Health, player1.MaxHealth);

                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    player1.Move(Input.GetDirection(
                        key,
                        ConsoleKey.LeftArrow,
                        ConsoleKey.RightArrow,
                        ConsoleKey.UpArrow,
                        ConsoleKey.DownArrow));

                    player2.Move(Input.GetDirection(key));
                }

                player1.Draw();
                player2.Draw();

                enemy.Draw();

                if(player1.Position == enemy.Position)
                {
                    player1.Health--;
                    player1.SetRandomPos();
                }
            }
        }

        void DrawHealthAndScore(int min, int max)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Healt: {min}/{max} --- Score: {score}");
        }
    }
}