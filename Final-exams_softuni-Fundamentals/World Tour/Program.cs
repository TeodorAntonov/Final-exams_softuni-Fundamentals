using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;


namespace REgex2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] cmd = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];

                if (action == "Add Stop")
                {
                    int index = int.Parse(cmd[1]);
                    string stop = cmd[2];

                    if (index >= 0 && index < input.Length)
                    {
                        input = input.Insert(index, stop);
                    }
                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(cmd[1]);
                    int endIndex = int.Parse(cmd[2]);

                    if (startIndex >= 0 && endIndex < input.Length)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex + 1);
                    }
                }
                else if (action == "Switch")
                {
                    string oldStr = cmd[1];
                    string newStr = cmd[2];

                    if (input.Contains(oldStr))
                    {
                        input = input.Replace(oldStr, newStr);
                    }

                }
                Console.WriteLine(input);

                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
