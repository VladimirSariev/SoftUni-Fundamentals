using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> output = new Dictionary<string, Hero>();
            for (int i = 0; i < rotations; i++)
            {
                string[] heroesInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = heroesInfo[0];
                int health = int.Parse(heroesInfo[1]);
                int mana = int.Parse(heroesInfo[2]);
                Hero heroes = new Hero(name, health, mana);
                output.Add(name, heroes);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End") 
            {
                string[] splitInput = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = splitInput[0];

                if (command == "CastSpell")
                {
                    string heroName = splitInput[1];
                    int manaNeeded = int.Parse(splitInput[2]);
                    string spellName = splitInput[3];

                    if (output[heroName].Mana >= manaNeeded)
                    {
                        output[heroName].Mana -= manaNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {output[heroName].Mana} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }

                else if (command == "TakeDamage")
                {
                    string heroName = splitInput[1];
                    int damage = int.Parse(splitInput[2]);
                    string attackerName = splitInput[3];

                    output[heroName].Health -= damage;
                    if (output[heroName].Health > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attackerName} and now has {output[heroName].Health} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attackerName}!");
                        output.Remove(heroName);
                    }
                }

                else if (command == "Recharge")
                {
                    string heroName = splitInput[1];
                    int amount = int.Parse(splitInput[2]);
                    int oldMana = output[heroName].Mana;
                    output[heroName].Mana += amount;
                    if (output[heroName].Mana >= 200)
                    {
                        amount = 200 - oldMana;
                        output[heroName].Mana = 200;
                    }
                    Console.WriteLine($"{heroName} recharged for {amount} MP!");
                }

                else if (command == "Heal")
                {
                    string heroName = splitInput[1];
                    int amount = int.Parse(splitInput[2]);
                    int oldHeroHealth = output[heroName].Health;
                    output[heroName].Health += amount;
                    if (output[heroName].Health > 100)
                    {
                        amount = 100 - oldHeroHealth;
                        output[heroName].Health = 100;
                       
                    }
                    Console.WriteLine($"{heroName} healed for {amount} HP!");
                }

            }


            foreach (var hero in output)
            {

                string name = hero.Key;
                int health = hero.Value.Health;
                int mana = hero.Value.Mana;
                Console.WriteLine($"{name}");
                Console.WriteLine($" HP: {health}");
                Console.WriteLine($" MP: {mana}");

            }
        }
    }

    class Hero
    {
        public Hero(string name, int health, int mana)
        {
            this.Name = name;
            this.Health = health;
            this.Mana = mana;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }

    }

}
