using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Problem_2._Mirror_words
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();

            Regex pathern = new Regex(@"([@#])([A-Za-z]{3,})\1{2}([A-Za-z]{3,})\1");

            string input = Console.ReadLine();

            MatchCollection matches = pathern.Matches(input);


            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            foreach (Match match in matches)
            {
                string word = match.Groups[2].Value;
                string mirror = match.Groups[3].Value;

                string reverse = mirror;
                char[] reverseMirror = reverse.ToCharArray();
                Array.Reverse(reverseMirror);
                string mirrorWord = new string(reverseMirror);

                if (word == mirrorWord)
                {
                    mirrorWords.Add(word, mirror);
                }
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                int count = 0;
                Console.WriteLine("The mirror words are:");
                foreach (var item in mirrorWords)
                {
                    count++;
                    if (count == mirrorWords.Count)
                    {
                        Console.Write($"{item.Key} <=> {item.Value}");
                    }
                    else
                    {
                        Console.Write($"{item.Key} <=> {item.Value}, ");
                    }
                }
            }

        }
    }
}