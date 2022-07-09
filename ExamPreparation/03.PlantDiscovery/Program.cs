using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();

            for (int i = 1; i <= rotations; i++)
            {
                string[] currInput = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string plantName = currInput[0];
                int plantRarity = int.Parse(currInput[1]);
                List<double> rating = new List<double>();

                Plant currentPlant = new Plant(plantName, plantRarity, rating);

                if (plants.Any(x => x.PlantName.Contains(plantName)))
                {
                   
                    foreach (Plant item in plants)
                    {
                        if (item.PlantName == plantName)
                        {
                            item.Rarity = plantRarity;
                            
                        }
                    }
                    
                }
                else
                {
                    plants.Add(currentPlant);
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] arr = new string[2] { ": ", " - " };
                string[] cmndArgs = input
                    .Split(arr, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = cmndArgs[0];

                if (command == "Rate")
                {
                    string currPlant = cmndArgs[1];
                    double currentRating = double.Parse(cmndArgs[2]);
                    if (!plants.Any(x => x.PlantName == currPlant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    
                        foreach (Plant names in plants)
                        {
                            if (names.PlantName == currPlant)
                            {
                                names.Rating.Add(currentRating);
                            break;
                            }
                        }
                    
                }

                else if (command == "Update")
                {
                    string currPlant = cmndArgs[1];
                    int currRarity = int.Parse(cmndArgs[2]);
                    
                    if (!plants.Any(x => x.PlantName == currPlant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    foreach (Plant rar in plants)
                    {
                        if (rar.PlantName == currPlant)
                        {
                            rar.Rarity = currRarity;
                            break;
                        }
                    }
                }

                else if (command == "Reset")
                {
                    string currPlant = cmndArgs[1];
                    if (!plants.Any(x => x.PlantName == currPlant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    foreach (Plant name in plants)
                    {
                        if (name.PlantName == currPlant)
                        {
                            name.Rating.Clear();
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            double averageResult = 0;
            foreach (Plant name in plants)
            {
                string plName = name.PlantName;
                int plRarity = name.Rarity;
                double plRating = name.Rating.Sum();
                if (plRating != 0 && name.Rating.Count != 0)
                {
                    averageResult = plRating / name.Rating.Count;
                }
                Console.WriteLine($"- {plName}; Rarity: {plRarity}; Rating: {averageResult:f2}");
            }
        }
    }
    class Plant
    {
        public Plant(string plantName, int rarity, List<double> rating)
        {
            this.PlantName = plantName;
            this.Rarity = rarity;
            this.Rating = rating;
        }
        public string PlantName { get; set; }
        public int Rarity { get; set; }
        public List<double> Rating { get; set; }
    }
}
