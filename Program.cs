using System.Diagnostics;

namespace Maskinskrivning
{
    internal class Program
    {
        static int score = 0;
        const int numberRounds = 10;

        static char[] characters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
            'l', 'm', 'n', 'o' , 'p' , 'q' , 'r' , 's' , 't' , 'u' , 'v' , 'w' , 'x',
            'y', 'z' , 'æ' , 'ø' , 'å' };

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine("Test your typewriting skills.\n" +
                "Type the letter as fast as possible.\n\n" +
                "Press any key to start.");
            Console.ReadKey(true);

            Stopwatch stopwatch = new();
            stopwatch.Start();
            for (int i = 0; i < numberRounds; i++)
            {
                Start();
            }
            stopwatch.Stop();
            Show("Time: " + stopwatch.Elapsed.ToString("mm\\:ss\\.ff"), 10, 15, ConsoleColor.Yellow);
        }

        private static void Start()
        {
            char randomChar = characters[rnd.Next(characters.Length)];
            Show(randomChar, 20, 10);

            char userChar = GetCharInput();

            if (randomChar == userChar)
            {
                Show("".PadRight(30),10,12);
                Show($"Congratz!. Score :{++score}", 10, 12, ConsoleColor.Green);
            }
            else
            {
                Show("".PadRight(30), 10, 12);
                Show($"Wrong! {score}", 10, 12, ConsoleColor.Red);
            }
        }

        private static char GetCharInput()
        {
            return Console.ReadKey(true).KeyChar;
        }

        //TODO Method for print with location and color
        static void Show(object text, int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(text.ToString());
        }

        //TODO method for showing letters already processed.


    }
}