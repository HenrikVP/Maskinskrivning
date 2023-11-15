using System.Xml.Serialization;

namespace Maskinskrivning
{
    internal class Io
    {
        static XmlSerializer serializer = new(typeof(int[]));
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static int[] LoadHighscore()
        {
            int[] highScore = new int[10];
            using (Stream reader = new FileStream(path + "/highscore.xml", FileMode.Open))
            {
                highScore = (int[])serializer.Deserialize(reader);
            }
            return highScore;
        }

        public static void SaveHighScore(int[] highScore)
        {
            using (FileStream stream = File.Create(path + "/highscore.xml"))
            {
                serializer.Serialize(stream, highScore);
            }
        }
    }
}
