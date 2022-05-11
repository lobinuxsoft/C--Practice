using System;
using System.Collections.Generic;

namespace Game.Class.Manager
{
    static class AchivementManager
    {
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

        public static AchivementData GetAchivementData(string achivementID) => achivements[achivementID].Data;
    }
}
