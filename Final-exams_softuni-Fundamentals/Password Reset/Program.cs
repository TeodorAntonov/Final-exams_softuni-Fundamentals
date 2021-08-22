using System;
using System.Text;

namespace Preparation_Final_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            string commnad = Console.ReadLine();

            while (commnad != "Done")
            {
                string[] cmd = commnad.Split();
                string comnd = cmd[0];

                if (comnd == "TakeOdd")
                {
                    for (int i = 1; i < input.Length; i += 2)
                    {
                        sb.Append(input[i]);
                    }
                    input = sb.ToString();
                    Console.WriteLine(input);
                }

                else if (commnad.Contains("Cut"))
                {
                    int index = int.Parse(cmd[1]);
                    int length = int.Parse(cmd[2]);

                    input = input.Remove(index, length);
                    Console.WriteLine(input);

                }

                else if (commnad.Contains("Substitute"))
                {
                    string oldChar = cmd[1];
                    string newChar = cmd[2];

                    if (!input.Contains(oldChar))
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                    else
                    {
                        input = input.Replace(oldChar, newChar);
                        Console.WriteLine(input);
                    }
                }

                commnad = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {input}");
        }
    }
}