using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Problem_3._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> carsFuel = new Dictionary<string, int>();
            Dictionary<string, int> carsMiles = new Dictionary<string, int>();

            Dictionary<string, (int miles, int fuel)> AllCarsInfo = new Dictionary<string, (int miles, int fuel)>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cars = Console.ReadLine().Split("|");

                string car = cars[0];
                int mileage = int.Parse(cars[1]);
                int fuel = int.Parse(cars[2]);

                carsFuel.Add(car, fuel);
                carsMiles.Add(car, mileage);
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] cmd = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];
                string car = cmd[1];
                int distace_refuel_km = int.Parse(cmd[2]);

                if (action == "Drive")
                {
                    int fuel = int.Parse(cmd[3]);

                    if (carsFuel[car] >= fuel)
                    {
                        carsMiles[car] += distace_refuel_km;
                        carsFuel[car] -= fuel;

                        Console.WriteLine($"{car} driven for {distace_refuel_km} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }

                    if (carsMiles[car] >= 100000)
                    {
                        carsFuel.Remove(car);
                        carsMiles.Remove(car);
                        Console.WriteLine($"Time to sell the {car}!");
                    }
                }

                if (action == "Refuel")
                {
                    carsFuel[car] += distace_refuel_km;

                    if (carsFuel[car] >= 75)
                    {
                        int total = carsFuel[car] - 75;

                        distace_refuel_km -= total;

                        carsFuel[car] = 75;

                    }

                    Console.WriteLine($"{car} refueled with {distace_refuel_km} liters");
                }

                if (action == "Revert")
                {
                    carsMiles[car] -= distace_refuel_km;

                    if (carsMiles[car] < 10000)
                    {
                        carsMiles[car] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {distace_refuel_km} kilometers");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in carsFuel)
            {
                AllCarsInfo.Add(item.Key, (0, item.Value));
            }
            foreach (var item in carsMiles)
            {
                AllCarsInfo[item.Key] = (item.Value, AllCarsInfo[item.Key].fuel);
            }

            foreach (var cars in AllCarsInfo.OrderByDescending(x => x.Value.miles).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{cars.Key} -> Mileage: {cars.Value.miles} kms, Fuel in the tank: {cars.Value.fuel} lt.");
            }
        }
    }
}
