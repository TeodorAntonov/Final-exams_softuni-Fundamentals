using System;
using System.Text;

namespace _01_Final_exam_The_imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            string command = Console.ReadLine();
            while (command != "Decode")
            {
                string[] cmd = command.Split('|');
                string action = cmd[0];

                if (action == "Move")
                {
                    int numOfLetters = int.Parse(cmd[1]);

                    for (int i = 0; i < numOfLetters; i++)
                    {
                        sb.Append(input[i]);
                    }
                    input = input.Remove(0, numOfLetters);
                    input = input + sb.ToString();

                    sb.Clear();
                }
                if (action == "Insert")
                {
                    int index = int.Parse(cmd[1]);
                    string value = cmd[2];

                    if (index >= 0 || index <= input.Length)
                    {
                        input = input.Insert(index, value);
                    }
                }

                if (action == "ChangeAll")
                {
                    string oldChar = cmd[1];
                    string newChar = cmd[2];

                    input = input.Replace(oldChar, newChar);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}