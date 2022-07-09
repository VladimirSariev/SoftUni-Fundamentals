using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string currCities = Console.ReadLine();
            List<City> cities = new List<City>();
            while (currCities != "Sail")
            {
                string[] splitCities = currCities
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string city = splitCities[0];
                int population = int.Parse(splitCities[1]);
                int gold = int.Parse(splitCities[2]);
                City currentCities = new City(city, population, gold);
                if (cities.Any(x => x.CurrentCity == city))
                {
                    FindCity(cities, currentCities, city, population, gold);
                }
                else
                {
                    cities.Add(currentCities);
                }
                
                currCities = Console.ReadLine();

            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArg = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commandArg[0];
                string town = commandArg[1];

                if (command == "Plunder")
                {
                    int population = int.Parse(commandArg[2]);
                    int gold = int.Parse(commandArg[3]);
                    PlunderedCity(cities, town, population, gold);
                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(commandArg[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }
                    else
                    {
                        GoldIncrease(cities, town, gold);
                       
                    }
                    
                }

            }

            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                PrintTheOutput(cities);
            }
        }
        static void PrintTheOutput(List<City> cities)
        {
            foreach (var town in cities)
            {
                string city = town.CurrentCity;
                int population = town.Population;
                int gold = town.Gold;
                Console.WriteLine($"{city} -> Population: {population} citizens, Gold: {gold} kg");
            }
        }
        static void GoldIncrease(List<City> cities, string town, int gold)
        {
            foreach (var city in cities)
            {
                if (city.CurrentCity == town)
                {
                    city.Gold += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {city.Gold} gold.");
                    break;
                }
            }
        }
        static void PlunderedCity (List<City> cities, string town, int population, int gold)
        {
            foreach (var city in cities)
            {
                if (city.CurrentCity == town)
                {
                    city.Population -= population;
                    city.Gold -= gold;
                    Console.WriteLine($"{city.CurrentCity} plundered! {gold} gold stolen, {population} citizens killed.");
                    if (city.Population <= 0 || city.Gold <= 0)
                    {
                        Console.WriteLine($"{city.CurrentCity} has been wiped off the map!");
                        cities.Remove(city);
                        break;
                    }
                }
            }
        }
       static void FindCity(List<City> cities, City currentCities, string city, int population, int gold)
        {
            foreach (var item in cities)
            {
                if (item.CurrentCity == city)
                {
                    item.Population += population;
                    item.Gold += gold;
                    break;
                }
            }
        }
    }
    class City
    {
        public City(string currentCity, int population, int gold)
        {
            this.CurrentCity = currentCity;
            this.Population = population;
            this.Gold = gold;
        }
        public string CurrentCity { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
