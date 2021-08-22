using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"([=\/])([A-Z][A-Za-z]{2,})\1");

            string input = Console.ReadLine();

            MatchCollection matches = pattern.Matches(input);
            int count = 0;

            Console.Write("Destinations: ");
            foreach (Match item in matches)
            {
                count++;
                if (count == matches.Count)
                {
                    Console.Write(item.Groups[2].Value);

                }
                else
                {
                    Console.Write(item.Groups[2].Value + ", ");
                }
            }

            Console.WriteLine();

            int totalPoints = 0;

            foreach (Match item in matches)
            {
                string len = item.Groups[2].Value;
                int lenght = len.Length;

                totalPoints += lenght;
            }
            Console.WriteLine($"Travel Points: {totalPoints}");
        }
    }
}
