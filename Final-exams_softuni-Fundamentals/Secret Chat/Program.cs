using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            while (command != "Reveal")
            {
                string[] cmd = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];

                if (action == "InsertSpace")
                {
                    int indexSubstring = int.Parse(cmd[1]);

                    if (indexSubstring >= 0 && indexSubstring < input.Length)
                    {
                        input = input.Insert(indexSubstring, " ");
                    }

                    Console.WriteLine(input);
                }
                if (action == "Reverse")
                {
                    string indexSubstring = cmd[1];
                    char[] charArray = indexSubstring.ToCharArray();
                    Array.Reverse(charArray);

                    if (input.Contains(indexSubstring))
                    {
                        string str = new string(charArray);

                        Regex regPLace = new Regex(indexSubstring);

                        input = regPLace.Replace(input, "", 1);
                        input = input + str;
                        //input = input + str;
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("error");  

                    }
                }

                if (action == "ChangeAll")
                {
                    string Substring = cmd[1];
                    string replacement = cmd[2];

                    input = input.Replace(Substring, replacement);
                    Console.WriteLine(input);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}