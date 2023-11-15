using System.Diagnostics;

namespace Maskinskrivning
{
    internal class Program
    {
        //TODO Highscore
        //TODO method for showing letters already processed.
        static int score = 0;
        const int numberRounds = 2;
        static string[] highScore = new string[10];

        static char[] characters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
            'l', 'm', 'n', 'o' , 'p' , 'q' , 'r' , 's' , 't' , 'u' , 'v' , 'w' , 'x',
            'y', 'z' , 'æ' , 'ø' , 'å' };

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                ShowHighscore();
                Game();
                Show("Try again? (Y/N)", 10, 6);
            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        static void ShowHighscore()
        {
            Show("***HIGHSCORE***", 50, 2, ConsoleColor.Cyan);
            for (int i = 0; i < highScore.Length; i++)
            {
                if (highScore[i] != null)
                    Show(highScore[i], 50, 4 + i, ConsoleColor.Cyan);
            }
        }

        static void Game()
        {
            score = 0;
            Console.CursorVisible = false;
            Show("Test your typewriting skills.\n" +
                "Type the letter as fast as possible.\n\n" +
                "Press any key to start.", 0, 2);
            Console.ReadKey(true);
            Console.Clear();
            ShowHighscore();


            Stopwatch stopwatch = new();
            stopwatch.Start();
            for (int i = 0; i < numberRounds; i++)
            {
                Start(i);
            }
            stopwatch.Stop();

            string timer = stopwatch.Elapsed.ToString(@"mm\:ss\.ff");
            //TODO Is score REALLY a highscore???

            AddToHighScore(score);

            Show("Time: " + timer, 10, 5, ConsoleColor.Yellow);
        }

        static void AddToHighScore(int score)
        {

            
        }

        static void Start(int i)
        {
            char randomChar = characters[rnd.Next(characters.Length)];

            Stopwatch keyStopWatch = new();
            keyStopWatch.Start();
            Show(randomChar, 10 + i * 2, 3);

            char userChar = GetCharInput();
            keyStopWatch.Stop();
            score += Math.Max(0, 3000 - (int)keyStopWatch.ElapsedMilliseconds);
            if (randomChar == userChar)
                Show($"Congratz! Score :{score}".PadRight(30), 10, 4, ConsoleColor.Green);
            else
                Show($"Wrong! Score :{score}".PadRight(30), 10, 4, ConsoleColor.Red);
        }

        static char GetCharInput()
        {
            return Console.ReadKey(true).KeyChar;
        }

        static void Show(object text, int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(text.ToString());
        }
    }
}