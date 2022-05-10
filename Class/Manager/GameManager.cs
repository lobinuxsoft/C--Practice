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

        Entity powerUp;

        private Enemy enemy;

        public void Run()
        {
            Console.CursorVisible = false;

            player1 = new Player('☺', Vector2.Zero, 5);
            player1.Color = ConsoleColor.Blue;
            player1.ScreenMargin = new Vector2(2, 2);
            player1.Name = "P1";
            player1.SetRandomPos();

            player2 = new Player('☻', Vector2.Zero, 5);
            player2.Color = ConsoleColor.Red;
            player2.ScreenMargin = new Vector2(2, 2);
            player2.Name = "P2";
            player2.SetRandomPos();

            enemy = new Enemy('☻', Vector2.One);
            enemy.Color = ConsoleColor.DarkMagenta;
            enemy.ScreenMargin = new Vector2(2, 2);

            while (isPlaying)
            {
                if((!player1.IsAttack && !player2.IsAttack) && powerUp == null)
                {
                    powerUp = new Entity('♦');
                    powerUp.Color = ConsoleColor.Green;
                    powerUp.ScreenMargin = new Vector2(2, 2);
                    powerUp.SetRandomPos();
                }
                else
                {
                    if (powerUp != null)
                    {
                        powerUp.Draw();

                        if (player1.Position == powerUp.Position)
                        {
                            player1.IsAttack = true;
                            powerUp = null;
                        }
                        else if (player2.Position == powerUp.Position)
                        {
                            player2.IsAttack = true;
                            powerUp = null;
                        }
                    }
                }

                DrawHealthAndScore(player1, score, Vector2.Zero);
                DrawHealthAndScore(player2, score, new Vector2(0, 1));

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
                    if (player1.IsAttack)
                    {
                        enemy.SetRandomPos();
                        score++;
                        player1.IsAttack = false;
                    }
                    else
                    {
                        player1.Health--;
                        player1.SetRandomPos();
                    }
                }
                else if(player2.Position == enemy.Position)
                {
                    if (player2.IsAttack)
                    {
                        enemy.SetRandomPos();
                        score++;
                        player2.IsAttack = false;
                    }
                    else
                    {
                        player2.Health--;
                        player2.SetRandomPos();
                    }
                }
            }
        }

        void DrawHealthAndScore(Player player, int score, Vector2 pos)
        {
            Console.ResetColor();
            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine($"{player.Name} Healt: {player.Health}/{player.MaxHealth} [Attak: {player.IsAttack}] --- Score: {score:0000} ");
        }
    }
}