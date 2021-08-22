using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, (int hp, int mp)> heroes = new Dictionary<string, (int hp, int mp)>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] hero = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                heroes.Add(hero[0], (int.Parse(hero[1]), int.Parse(hero[2])));
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmd = command.Split(" - ");
                string action = cmd[0];
                string heroName = cmd[1];
                int hp = heroes[heroName].hp;
                int mp = heroes[heroName].mp;

                int dmg_amount_rech_heal = int.Parse(cmd[2]);

                if (action == "CastSpell")
                {
                    string spellName = cmd[3];

                    if (mp >= dmg_amount_rech_heal)
                    {
                        int mpLeft = mp - dmg_amount_rech_heal;

                        heroes[heroName] = (hp, mpLeft);
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {mpLeft} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                if (action == "TakeDamage")
                {
                    string attacker = cmd[3];
                    int hpLeft = hp - dmg_amount_rech_heal;

                    if (hpLeft > 0)
                    {
                        heroes[heroName] = (hpLeft, mp);
                        Console.WriteLine($"{heroName} was hit for {dmg_amount_rech_heal} HP by {attacker} and now has {hpLeft} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(heroName);

                    }
                }

                if (action == "Recharge")
                {
                    if (mp < 200)
                    {
                        int recharged = mp + dmg_amount_rech_heal;

                        if (recharged >= 200)
                        {
                            recharged = 200;
                        }

                        heroes[heroName] = (hp, recharged);

                        int amountMana = recharged - mp;
                        Console.WriteLine($"{heroName} recharged for {amountMana} MP!");
                    }
                }

                if (action == "Heal")
                {
                    if (hp <= 100)
                    {
                        int heal = hp + dmg_amount_rech_heal;

                        if (heal > 100)
                        {
                            heal = 100;
                        }

                        heroes[heroName] = (heal, mp);

                        int amountHP = heal - hp;
                        Console.WriteLine($"{heroName} healed for {amountHP} HP!");
                    }
                }
                command = Console.ReadLine();
            }

            foreach (var hero in heroes.OrderByDescending(x => x.Value.hp).ThenBy(x => x.Key))
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.hp}");
                Console.WriteLine($"  MP: {hero.Value.mp}");
            }
        }
    }
}
