using Game.Class.Objects;
using Game.Structs;
using System;
using AchivementSystemDLL;
using Game.Class.Interfaces;
using System.Collections.Generic;

namespace Game.Class.Manager
{

    class GameManager
    {
        private const int enemiesAmount = 10;

        int scoreP1 = 0;
        int scoreP2 = 0;

        private bool isPlaying = true;

        private Player player1;
        private Player player2;

        Entity powerUp;

        private  List<Enemy> enemies = new List<Enemy>();

        public void Run()
        {
            Console.CursorVisible = false;

            player1 = new Player('☺', Vector2.Zero, 5);
            player1.Color = ConsoleColor.Blue;
            player1.ScreenMargin = new Vector2(2, 2);
            player1.Name = "P1";
            player1.SetRandomPos();

            player2 = new Player('☻', Vector2.Zero, 5);
            player2.Color = ConsoleColor.Green;
            player2.ScreenMargin = new Vector2(2, 2);
            player2.Name = "P2";
            player2.SetRandomPos();

            EnemyConstructor();

            while (isPlaying)
            {
                if((!player1.IsAttack && !player2.IsAttack) && powerUp == null)
                {
                    powerUp = new Entity('♦');
                    powerUp.Color = ConsoleColor.Cyan;
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

                DrawHealthAndScore(player1, scoreP1, Vector2.Zero);
                DrawHealthAndScore(player2, scoreP2, new Vector2(0, 1));

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

                foreach (var enemy in enemies)
                {
                    enemy.Draw();

                    if(player1.Position == enemy.Position)
                    {
                        if (player1.IsAttack)
                        {
                            enemy.SetRandomPos();
                            scoreP1++;
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
                            scoreP2++;
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
        }

        void DrawHealthAndScore(Player player, int score, Vector2 pos)
        {
            Console.ResetColor();
            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine($"{player.Name} Healt: {player.Health}/{player.MaxHealth} [Attak: {player.IsAttack}] --- Score: {score:0000} ");
        }

        void EnemyConstructor()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            int enemyMovementStyle;
            Enemy enemy;
            Vector2 pos = Vector2.Zero;

            for (int i = 0; i < enemiesAmount; i++)
            {
                enemyMovementStyle = rnd.Next(2);

                pos.x = rnd.Next(0, Console.WindowWidth);
                pos.y = rnd.Next(0, Console.WindowHeight);

                switch (enemyMovementStyle)
                {
                    case 0:
                        
                        enemy = new Enemy((char)i, pos, new RandomMovement());
                        enemy.Color = ConsoleColor.DarkMagenta;
                        enemy.ScreenMargin = new Vector2(2, 2);
                        enemies.Add(enemy);
                        break;
                    case 1:
                        enemy = new Enemy((char)i, pos, new DiagonalMovement());
                        enemy.Color = ConsoleColor.DarkRed;
                        enemy.ScreenMargin = new Vector2(2, 2);
                        enemies.Add(enemy);
                        break;
                }
            }
        }
    }
}