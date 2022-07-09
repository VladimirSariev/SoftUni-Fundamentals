using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string input = Console.ReadLine();

                string[] splitInput = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = splitInput[0];

                switch (command)
                {
                    case "Include":
                        string coffeeType = splitInput[1];
                        coffees.Add(coffeeType);
                        break;
                    case "Remove":
                        string firstOrLast = splitInput[1];
                        int numbersOfCoffeesToRemove = int.Parse(splitInput[2]);

                        if (numbersOfCoffeesToRemove > coffees.Count)
                        {
                            continue;
                        }
                        else
                        {
                            if (firstOrLast == "first")
                            {
                                for (int first = 0; first < numbersOfCoffeesToRemove; first++)
                                {
                                    coffees.RemoveAt(0);
                                }
                            }
                            else
                            {
                                for (int last = 0; last < numbersOfCoffeesToRemove; last++)
                                {
                                    coffees.RemoveAt(coffees.Count - 1);
                                }
                            }
                        }
                        break;

                    case "Prefer":
                        int firstIndex = int.Parse(splitInput[1]);
                        int secondIndex = int.Parse(splitInput[2]);

                        if (firstIndex >= 0 && firstIndex < coffees.Count
                            && secondIndex >= 0 && secondIndex < coffees.Count)
                        {
                            string firstCoffee = coffees[firstIndex];
                            string secondCoffee = coffees[secondIndex];

                            coffees.RemoveAt(firstIndex);
                            coffees.Insert(firstIndex, secondCoffee);
                            coffees.RemoveAt(secondIndex);
                            coffees.Insert(secondIndex, firstCoffee);


                        }
                        else
                        {
                            continue;
                        }
                        break;

                    case "Reverse":
                        coffees.Reverse();
                        break;
                }
            }
            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(' ', coffees));
        }
    }
}
