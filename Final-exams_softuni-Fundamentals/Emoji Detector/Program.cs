using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Regex_templ
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pathern = new Regex(@"([:*])\1([A-Z][a-z]{2,})\1{2}");

            string input = Console.ReadLine();
            long multiPly = 1;
            char chr;

            for (int i = 0; i < input.Length; i++)
            {
                chr = input[i];
                if (char.IsDigit(chr))
                {
                    int numNum = chr - 48;

                    multiPly *= numNum;
                }
            }

            Console.WriteLine($"Cool threshold: {multiPly}");

            MatchCollection matches = pathern.Matches(input);

            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in matches)
            {
                int totalSum = 0;

                string group = match.Groups[2].Value;

                for (int i = 0; i < group.Length; i++)
                {
                    totalSum += group[i];
                }

                if (totalSum >= multiPly)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
