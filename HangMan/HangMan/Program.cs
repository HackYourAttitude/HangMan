using System;
using System.Linq;
using HangMan;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string words = OpenFile.ReadFile("C:\\Users\\48602\\Desktop\\HangMan\\CountriesCapitals.csv");
            string word = Program.GiveSingleWord(words);
            string level = Program.ChooseDifficultyLevel();

        }

        public static string GiveSingleWord(string words)
        {
            Random random = new Random();
            var ListOfWords = words.Trim().Split('\n', ' ');
            return ListOfWords[random.Next(ListOfWords.Length)];
        }

        public static string ChooseDifficultyLevel()
        {
            Console.WriteLine("Choose Game Level :");
            Console.WriteLine("");
            Console.WriteLine("Press '1' for Easy ==> 5 lifes");
            Console.WriteLine("Press '2' for Midium ==> 4 lifes");
            Console.WriteLine("Press '3' for Hard ==> 3 lifes");
            while (true)
            {
                string level = Console.ReadLine();
                string[] options = { "1", "2", "3" };
                if (level.Length == 1 && options.Contains(level))
                    return level;
                Console.WriteLine("Sorry wrong input  !!! Try again");
            }


        }

    }

}
