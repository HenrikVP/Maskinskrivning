namespace Maskinskrivning
{
    internal class Program
    {
        static int score = 0;

        static char[] characters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 
            'l', 'm', 'n', 'o' , 'p' , 'q' , 'r' , 's' , 't' , 'u' , 'v' , 'w' , 'x', 
            'y', 'z' , 'æ' , 'ø' , 'å' };

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            //Console.WriteLine(characters[0]);
            //Console.WriteLine(characters[characters.Length - 1]);

            //TODO Start a timer

            for (int i = 0; i < 10; i++)
            {
                Start();
            }
        }

        private static void Start()
        {
            //TODO make char instead of int
            int i = rnd.Next(characters.Length);

            //TODO Show letter same place always
            Console.WriteLine(characters[i]);
            char c = GetCharInput();

            bool isSame = Compare(characters[i], c);

            if (isSame)
            {
                Console.WriteLine($"Congratz!. They are the same. Score :{++score}");
            }
            //TODO ELSE OH NO!
        }

        private static bool Compare(char v, char c)
        {
            return v == c;
        }

        private static char GetCharInput()
        {
            //TODO Dont show char pressed
            return Console.ReadKey().KeyChar;
        }

        //TODO Method for print with location and color

        //TODO method for showing letters already processed.

    }
}