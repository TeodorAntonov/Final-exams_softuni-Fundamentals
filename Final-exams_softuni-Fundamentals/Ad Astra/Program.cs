using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Regex21
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pathern = new Regex(@"([#|])([A-Za-z ]+)\1([\d]{2}\/[\d]{2}\/[\d]{2})\1([0-9]+)\1");

            string str = Console.ReadLine();

            MatchCollection matches = pathern.Matches(str);

            int total = 0;

            foreach (Match item in matches)
            {
                int val = int.Parse(item.Groups[4].Value);
                total += val;
            }

            Console.WriteLine($"You have food to last you for: {total / 2000} days!");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups[2].Value}, Best before: {match.Groups[3].Value}, Nutrition: {match.Groups[4].Value}");
            }
        }
    }
}