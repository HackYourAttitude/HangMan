using System;
using System.Collections.Generic;
using System.Linq;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunGame();           
        }

        public static void RunGame()
        {
            string words = OpenFile.ReadFile("C:\\Users\\48602\\Desktop\\HangMan\\CountriesCapitals.csv");
            string word = GiveSingleWord(words).Trim();
            Console.WriteLine(word+""+word.Length);
            string[] ListOfLetters = new string[word.Length];
            string level = ChooseDifficultyLevel();
            GenerateHashedWord(ListOfLetters, word.Length);
            int lifes = SetLifeLimit(level);
            DisplayWord(ListOfLetters);
            while(true)
            {
                string letter = GuesTheLetter();
                InputLetter(ListOfLetters, letter, word);
                DisplayWord(ListOfLetters);
            }
            
        }

        public static int SetLifeLimit(string level)
        {
            int lifes;
            switch (level)
            {
                case "1":
                    lifes = 5;
                    break;
                case "2":
                    lifes = 4;
                    break;
                case "3":
                    lifes = 3;
                    break;
                default:
                    throw new Exception("Sorry Something went wrong, try again....");
            }
            return lifes;
        }


        public static string GiveSingleWord(string words)
        {
            while (true)
            {
                Random random = new Random();
                var ListOfWords = words.Split('\n', ' ');
                string word = ListOfWords[random.Next(ListOfWords.Length)];
                if (word.Length < 30)
                    return word;
            }       
            
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
                {
                    Console.Clear();
                    return level;
                }                   
                Console.WriteLine("Sorry wrong input  !!! Try again");
            }
        }

        public static void GenerateHashedWord(string[]ListOfLetters,int wordLength)
        {
            for(int i = 0;i < wordLength;i++)
            {
                ListOfLetters[i] = "_ ";
            }
         
        }
        public static void  DisplayWord(string[]ListOfLetters)
        {
            foreach (var item in ListOfLetters)
            {
                Console.Write(item);
            }
            Console.WriteLine("");
        }

        public static string GuesTheLetter()
        {
            Console.WriteLine("Letter : ");
            string letters = "ABCDEFGHIJKLMNOPQRSTUWXYZ";
            while(true)
            {
                string letter = Console.ReadLine();
                Console.Clear();
                if (letter.Length == 1 && letters.Contains(letter.ToUpper()))
                    return letter.ToUpper();
                Console.WriteLine("Wrong input, try again !!!");
            }
            
        }

        public static void InputLetter(string[] ListOfLetters,string letter,string word)
        {
            for(int x = 0; x <word.Length;x++)
            {
                if (letter.ToUpper() == Convert.ToString(word[x]).ToUpper())
                {
                    ListOfLetters[x] = letter.ToUpper();
                }
            }

        }

        public static int LifeController(int lifes)
        {
            return lifes--;

        }

    }

}
