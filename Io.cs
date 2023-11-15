using System.Xml.Serialization;

namespace Maskinskrivning
{
    internal class Io
    {
        public static int[] LoadHighscore()
        {
            int[] highScore = new int[10];
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (Stream reader = new FileStream(path + "/highscore.xml", FileMode.Open))
            {
                XmlSerializer serializer = new(typeof(int[]));
                highScore = (int[])serializer.Deserialize(reader);
            }
            return highScore;
        }

        public static void SaveHighScore(int[] highScore)
        {
            string url = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (FileStream stream = File.Create(url + "/highscore.xml"))
            {
                XmlSerializer serializer = new(typeof(int[]));
                serializer.Serialize(stream, highScore);
            }
        }
    }
}
