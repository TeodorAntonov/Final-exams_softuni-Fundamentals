using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Regex_templ
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] cmd = command.Split(">>>");

                string action = cmd[0];

                if (action == "Contains")
                {
                    string substring = cmd[1];

                    if (input.Contains(substring))
                    {
                        Console.WriteLine($"{input} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }

                else if (action == "Flip")
                {
                    string upperAndLower = cmd[1];
                    int startIndex = int.Parse(cmd[2]);
                    int endIndex = int.Parse(cmd[3]);

                    if (startIndex < 0 || endIndex > input.Length)
                    {
                        continue;
                    }

                    if (upperAndLower == "Upper")
                    {
                        string str = input.Substring(startIndex, endIndex - startIndex).ToUpper();
                        input = input.Remove(startIndex, endIndex - startIndex);
                        input = input.Insert(startIndex, str);
                    }
                    else if (upperAndLower == "Lower")
                    {
                        string str = input.Substring(startIndex, endIndex - startIndex).ToLower();
                        input = input.Remove(startIndex, endIndex - startIndex);
                        input = input.Insert(startIndex, str);
                    }
                    Console.WriteLine($"{input}");
                }

                else if (action == "Slice")
                {
                    int startIndex = int.Parse(cmd[1]);
                    int endIndex = int.Parse(cmd[2]);

                    if (startIndex < 0 || endIndex > input.Length)
                    {
                        continue;
                    }
                    input = input.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine($"{input}");
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}