using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Regex4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, (int rarity, List<double> rating)> storedInfo = new Dictionary<string, (int rarity, List<double> rating)>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split("<->");
                string plant = command[0];
                int rarity = int.Parse(command[1]);

                if (storedInfo.ContainsKey(plant))
                {
                    int newRarity = storedInfo[plant].rarity + rarity;

                    storedInfo[plant] = (newRarity, new List<double>());

                    continue;
                }
                storedInfo.Add(plant, (rarity, new List<double>()));
            }

            string commandaX = Console.ReadLine();

            while (commandaX != "Exhibition")
            {
                string[] cmd = commandaX.Split(new char[] { ':', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];
                string plant = cmd[1];

                if (action == "Rate")
                {
                    if (storedInfo.ContainsKey(plant))
                    {
                        double rating = double.Parse(cmd[2]);
                        storedInfo[plant].rating.Add(rating);

                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (action == "Update")
                {
                    if (storedInfo.ContainsKey(plant))
                    {
                        int newRarity = int.Parse(cmd[2]);
                        storedInfo[plant] = (newRarity, storedInfo[plant].rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "Reset")
                {
                    if (storedInfo.ContainsKey(plant))
                    {
                        storedInfo[plant].rating.Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
                commandaX = Console.ReadLine();
            }


            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in storedInfo.OrderByDescending(x => x.Value.rarity).ThenByDescending(x => x.Value.rating.Count > 0 ? x.Value.rating.Sum() / x.Value.rating.Count : 0))
            {
                if (item.Value.rating.Count == 0 || item.Value.rating.Sum() == 0)
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {item.Value.rarity}; Rating: 0.00");
                    continue;
                }
                double total = item.Value.rating.Sum() / item.Value.rating.Count;
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.rarity}; Rating: {total:f2}");

            }
        }
    }
}