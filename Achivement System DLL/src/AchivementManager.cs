using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AchivementSystemDLL
{
    public static class AchivementManager
    {
        public static string path = $"{AppDomain.CurrentDomain.BaseDirectory}Achivement\\";

        static Dictionary<string, Achivement> achivements = new Dictionary<string, Achivement>();

        /// <summary>
        /// Records a new achievement, if it already exists ignores it.
        /// </summary>
        /// <param name="achivementID"></param>
        /// <param name="data"></param>
        public static void Register(string achivementID, AchivementData data)
        {
            if (!achivements.ContainsKey(achivementID)) achivements.Add(achivementID, new Achivement(data));
        }

        /// <summary>
        /// Removes the record of an achievement, if it does not exist it ignores it.
        /// </summary>
        /// <param name="achivementID"></param>
        public static void Unregister(string achivementID)
        {
            if (achivements.ContainsKey(achivementID)) achivements.Remove(achivementID);
        }

        /// <summary>
        /// Update the status of an achievement if it exists.
        /// </summary>
        /// <param name="achivementID"></param>
        public static void Update(string achivementID)
        {
            if (achivements.ContainsKey(achivementID) && !achivements[achivementID].IsUnlocked) achivements[achivementID].Count++;
        }

        /// <summary>
        /// Subscribe to an achievement to know when it's completed.
        /// </summary>
        /// <param name="achivementID"></param>
        /// <param name="action"></param>
        public static void Subscribe(string achivementID, Action<AchivementData> action)
        {
            if (achivements.ContainsKey(achivementID)) achivements[achivementID].onAchivementUnlock += action;
        }

        /// <summary>
        /// Unsubscribe to an achievement to not listen to it again, as long as it exists.
        /// </summary>
        /// <param name="achivementID"></param>
        /// <param name="action"></param>
        public static void UnSubscribe(string achivementID, Action<AchivementData> action)
        {
            if (achivements.ContainsKey(achivementID)) achivements[achivementID].onAchivementUnlock -= action;
        }

        /// <summary>
        /// Returns the achievement data, if the achievement exists.
        /// </summary>
        /// <param name="achivementID"></param>
        /// <returns></returns>
        public static AchivementData GetAchivementData(string achivementID)
        {
            if (achivements.ContainsKey(achivementID)) return achivements[achivementID].Data;
            else return new AchivementData();
        }

        /// <summary>
        /// Save the status of all recorded achievements.
        /// </summary>
        public static void SaveData()
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            List<AchivementData> achivementDatas = new List<AchivementData>();

            foreach (var data in achivements)
            {
                achivementDatas.Add(data.Value.Data);
            }

            string json = JsonConvert.SerializeObject(achivementDatas, Formatting.Indented);
            File.WriteAllText($"{path}Achivement.save", json);
        }

        /// <summary>
        /// Load achievements from a file.
        /// </summary>
        public static void LoadData()
        {
            if (File.Exists($"{path}Achivement.save"))
            {
                List<AchivementData> achivementDatas = JsonConvert.DeserializeObject<List<AchivementData>>(File.ReadAllText($"{path}Achivement.save"));

                if (achivementDatas != null && achivementDatas.Count > 0)
                {
                    foreach (var data in achivementDatas)
                    {
                        Register(data.Name, data);
                    }
                }
            }
        }
    }
}