using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Em_detector
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, (int population, int gold)> CitiesInfo = new Dictionary<string, (int population, int gold)>();

            string input = Console.ReadLine();

            while (input != "Sail")
            {
                string[] cmd = input.Split("||");
                string cities = cmd[0];
                int population = int.Parse(cmd[1]);
                int gold = int.Parse(cmd[2]);

                if (CitiesInfo.ContainsKey(cities))
                {
                    int newPop = CitiesInfo[cities].population + population;
                    int newGold = CitiesInfo[cities].gold + gold;

                    CitiesInfo[cities] = (newPop, newGold);
                }
                else
                {
                    CitiesInfo.Add(cities, (population, gold));
                }

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmd = command.Split("=>");
                string action = cmd[0];
                string town = cmd[1];
                int peopleOrGold = int.Parse(cmd[2]);

                if (action == "Plunder")
                {
                    if (CitiesInfo.ContainsKey(town))
                    {
                        int gold = int.Parse(cmd[3]);
                        int newPopulation = CitiesInfo[town].population - peopleOrGold;
                        int newGold = CitiesInfo[town].gold - gold;

                        if (newGold <= 0 || newPopulation <= 0)
                        {
                            Console.WriteLine($"{town} plundered! {gold} gold stolen, {peopleOrGold} citizens killed.");
                            Console.WriteLine($"{town} has been wiped off the map!");
                            CitiesInfo.Remove(town);

                        }
                        else
                        {
                            Console.WriteLine($"{town} plundered! {gold} gold stolen, {peopleOrGold} citizens killed.");
                            CitiesInfo[town] = (newPopulation, newGold);
                        }
                    }

                }

                if (action == "Prosper")
                {
                    if (CitiesInfo.ContainsKey(town))
                    {
                        int newGold = CitiesInfo[town].gold + peopleOrGold;

                        if (peopleOrGold < 0)
                        {
                            Console.WriteLine($"Gold added cannot be a negative number!");
                        }
                        else
                        {
                            Console.WriteLine($"{peopleOrGold} gold added to the city treasury. {town} now has {newGold} gold.");
                            CitiesInfo[town] = (CitiesInfo[town].population, newGold);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Ahoy, Captain! There are {CitiesInfo.Count} wealthy settlements to go to:");

            foreach (var town in CitiesInfo.OrderByDescending(X => X.Value.gold).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{town.Key} -> Population: {town.Value.population} citizens, Gold: {town.Value.gold} kg");
            }
        }
    }
}
