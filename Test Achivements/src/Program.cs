using AchivementSystemDLL;
using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            AchivementManager.Register("M", new AchivementData { Name = "Apretando la M", Description = "Apretando la M de manera furiosa", AmountToUnlock = 10, Count = 0 });
            AchivementManager.Subscribe("M", ListenerM);


            while (isRunning)
            {
                AchivementData data = AchivementManager.GetAchivementData("M");

                if(!string.IsNullOrEmpty(data.Name))
                {
                    Console.WriteLine($"Logro: {data.Name}, Contador: {data.Count}/{data.AmountToUnlock}");
                }

                if(Console.ReadKey(true).Key == ConsoleKey.M)
                {
                    AchivementManager.Update("M");
                }
            }
        }

        static void ListenerM(AchivementData data)
        {
            Console.WriteLine($"Logro: {data.Name}, Descripcion: {data.Description} => DESBLOQUEADO!");
            AchivementManager.UnSubscribe("M", ListenerM);
            AchivementManager.Unregister("M");
        }
    }

    
}