using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "TextFile1.csv";
            RunGame(fileName);           
        }

        public static void RunGame(string fileName)
        {
            
            string words = OpenFile.ReadFile(Path.GetFullPath(fileName));
            string word = GiveSingleWord(words).Trim();
            Console.WriteLine(word);
            List<string> ListOfLetters = new List<string>();
            string level = ChooseDifficultyLevel();
            GenerateHashedWord(ListOfLetters, word.Length);
            int lifes = SetLifeLimit(level);
            Display(ListOfLetters);
            LoopGame(word, lifes, ListOfLetters);         
        }
        public static void LoopGame(string word,int lifes,List<string> ListOfLetters)
        {
            List<string> ListOfUsedLetters = new List<string>();
            while (true)
            {
                string letter = GuesTheLetter();
                if (!SayIfLetterWasUsed(letter,ListOfUsedLetters))
                {
                    bool IsIn = InputLetter(ListOfLetters, letter, word);
                    AddLetterToTheList(letter,ListOfUsedLetters);
                    Display(ListOfUsedLetters);
                    if (!IsIn)
                        lifes = TakeLife(lifes);
                    CheckFailureCondition(lifes);
                    Display(ListOfLetters);
                    CheckWinCondition(ListOfLetters);
                }
                Info();              
            }
        }

        public static bool SayIfLetterWasUsed(string letter, List<string> ListOfUsedLetters)
        {
            return ListOfUsedLetters.Contains(letter);
        }

        public static void AddLetterToTheList(string letter,List<string> ListOfUsedLetters)
        {
            if (!SayIfLetterWasUsed(letter, ListOfUsedLetters))
                ListOfUsedLetters.Add(letter);

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
            Console.WriteLine("Press '2' for Medium ==> 4 lifes");
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

        public static void GenerateHashedWord(List<string>ListOfLetters,int wordLength)
        {
            for(int i = 0;i < wordLength;i++)
            {
                ListOfLetters.Add("_ ");
            }
         
        }
        public static void  Display(List<string>ListOfLetters)
        {
            Console.WriteLine("");
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

        public static bool InputLetter(List<string> ListOfLetters,string letter,string word)
        {
            bool flag = false;
            for(int x = 0; x <word.Length;x++)
            {
                if (letter.ToUpper() == Convert.ToString(word[x]).ToUpper())
                {
                    ListOfLetters[x] = letter.ToUpper();
                    flag = true;
                }
                
            }
            return flag;

        }

        public static int TakeLife (int lifes)
        {
            return lifes-=1;
        }

        public static void CheckFailureCondition(int lifes)
        {
            if(lifes == 0)
            {
                Console.WriteLine("Sorry No more Lifes left ...You Lost !!!");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
                
        }

        public static void CheckWinCondition(List<string>ListOfLetters)
        {
            foreach (var item in ListOfLetters)
            {
                if (item.Contains("_"))
                    return;
            }
            Console.WriteLine("Congratulation You have Won !!!");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        public static void Info()
        {
            Console.WriteLine("Sorry The letter was already used...");
        }



    }

}
