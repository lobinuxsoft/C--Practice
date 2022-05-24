using System.IO;

namespace Game.Class.Manager
{
    public static class FileReader
    {
        public static string LoadFile(string filePath)
        {
            FileStream fs = File.OpenRead(filePath);
            StreamReader sr = new StreamReader(fs);
            return sr.ReadToEnd();
        }
    }
}
