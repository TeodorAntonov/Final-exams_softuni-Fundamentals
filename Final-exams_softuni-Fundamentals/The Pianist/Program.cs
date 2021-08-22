using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Piano
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, (string author, string key)> pieces = new Dictionary<string, (string author, string key)>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                string sonata = input[0];
                string compose = input[1];
                string key = input[2];

                pieces.Add(sonata, (compose, key));
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] cmd = command.Split("|");
                string action = cmd[0];
                string sonata = cmd[1];

                if (action == "Add")
                {
                    string composer = cmd[2];
                    string key = cmd[3];

                    if (!pieces.ContainsKey(sonata))
                    {
                        pieces.Add(sonata, (composer, key));
                        Console.WriteLine($"{sonata} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{sonata} is already in the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (pieces.ContainsKey(sonata))
                    {
                        pieces.Remove(sonata);
                        Console.WriteLine($"Successfully removed {sonata}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {sonata} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string key = cmd[2];

                    if (pieces.ContainsKey(sonata))
                    {
                        pieces[sonata] = (pieces[sonata].author, key);
                        Console.WriteLine($"Changed the key of {sonata} to {pieces[sonata].key}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {sonata} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in pieces.OrderBy(x => x.Key).ThenBy(x => x.Value.author))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.author}, Key: {item.Value.key}");
            }
        }
    }
}
