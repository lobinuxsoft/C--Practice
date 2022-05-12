using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Game.Class.Manager
{
    static class AchivementManager
    {
        public static string path = $"{AppDomain.CurrentDomain.BaseDirectory}Achivement\\";

        static Dictionary<string, Achivement> achivements = new Dictionary<string, Achivement>();

        public static void Register(string achivementID, Achivement achivement)
        {
            if (!achivements.ContainsKey(achivementID)) achivements.Add(achivementID, achivement);
        }

        public static void Unregister(string achivementID)
        {
            if (achivements.ContainsKey(achivementID)) achivements.Remove(achivementID);
        }

        public static void Update(string achivementID)
        {
            if (achivements.ContainsKey(achivementID)) achivements[achivementID].Count++;
        }

        public static void Subscribe(string achivementID, Action<AchivementData> action)
        {
            if (achivements.ContainsKey(achivementID)) achivements[achivementID].onAchivementUnlock += action;
        }

        public static void UnSubscribe(string achivementID, Action<AchivementData> action)
        {
            if (achivements.ContainsKey(achivementID)) achivements[achivementID].onAchivementUnlock -= action;
        }

        public static AchivementData GetAchivementData(string achivementID) 
        {
            if(achivements.ContainsKey(achivementID)) return achivements[achivementID].Data;
            else return new AchivementData();
        }

        public static void SaveData()
        {
            if(!Directory.Exists(path)) Directory.CreateDirectory(path);

            List<AchivementData> achivementDatas = new List<AchivementData>();

            foreach (var data in achivements)
            {
                achivementDatas.Add(data.Value.Data);
            }

            string json = JsonConvert.SerializeObject(achivementDatas);
            File.WriteAllText($"{path}Achivement.save", json);
        }
    }
}
