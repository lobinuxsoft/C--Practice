using AchivementSystemDLL;
using System;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            SetupAchivements();

            while (isRunning)
            {
                //Console.Clear();
                CheckAchivementStatus("Apretando la A");
                CheckAchivementStatus("Apretando la M");
                CheckAchivementStatus("Apretando la Z");

                EvaluateAchivement(Console.ReadKey(true).Key);
            }
        }

        static void SetupAchivements()
        {
            AchivementManager.LoadData();

            AchivementManager.Register("Apretando la M", new AchivementData("Apretando la M", "Apretando la M de manera furiosa", 10));
            AchivementManager.Subscribe("Apretando la M", ListenAchivementManager);

            AchivementManager.Register("Apretando la A", new AchivementData("Apretando la A", "Apretando la A de manera furiosa", 10));
            AchivementManager.Subscribe("Apretando la A", ListenAchivementManager);

            AchivementManager.Register("Apretando la Z", new AchivementData("Apretando la Z", "Apretando la Z de manera furiosa... para mi que te gusta dormir xD", 10));
            AchivementManager.Subscribe("Apretando la Z", ListenAchivementManager);
        }

        static void ListenAchivementManager(AchivementData data)
        {
            Console.WriteLine($"Logro: {data.Name}, Descripcion: {data.Description} => DESBLOQUEADO!");
            AchivementManager.UnSubscribe(data.Name, ListenAchivementManager);
            AchivementManager.SaveData();
        }

        static void CheckAchivementStatus(string achivementKey)
        {
            AchivementData achivementData = AchivementManager.GetAchivementData(achivementKey);

            if (!string.IsNullOrEmpty(achivementData.Name))
            {
                Console.WriteLine($"Logro: {achivementData.Name}, Contador: {achivementData.Count}/{achivementData.AmountToUnlock}, Desbloqueado: {achivementData.IsUnlocked}");
            }
        }

        static void EvaluateAchivement(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    AchivementManager.Update("Apretando la A");
                    AchivementManager.SaveData();
                    break;
                case ConsoleKey.M:
                    AchivementManager.Update("Apretando la M");
                    AchivementManager.SaveData();
                    break;
                case ConsoleKey.Z:
                    AchivementManager.Update("Apretando la Z");
                    AchivementManager.SaveData();
                    break;
            }
        }
    }

    
}