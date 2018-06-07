using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesExercise
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to a file: ");
            var path = Console.ReadLine();
            WordCheck(path);
        }

        public static int CountWords(string file)
        {
            var text = File.ReadAllText(file);
            var words = new List<string>(text.Split(' '));
            return words.Count;
        }

        public static string LongestWord(string file)
        {
            var text = File.ReadAllText(file);
            var words = new List<string>(text.Split(' '));
            var max = 0;
            var longWord = "";
            foreach (var word in words)
                if (word.Length > max)
                {
                    max = word.Length;
                    longWord = word;
                }

            return longWord;
        }

        public static void WordCheck(string path)
        {
            do
            {
                if (String.IsNullOrEmpty(path) || path == "badPath")
                    path = Console.ReadLine();
                if (File.Exists(path))
                {
                    Console.WriteLine("There are " + CountWords(path) + " words in this file.");
                    Console.WriteLine("The longest word in the file is: " + LongestWord(path));
                }
                else
                {
                    Console.WriteLine("The path: " + path + " is not a valid path. Pleaser try again.");
                    path = "badPath";
                }
            } while (!File.Exists(path));

            return;
        }
    }
}
