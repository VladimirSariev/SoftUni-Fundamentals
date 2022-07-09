using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int[] dnaSequence = new int[numbers];

            int bestSum = 0;
            int bestDnaLenght = 0;
            int bestStart = 0;
            int dnaSample = 0;
            int bestDnaSample = 0;


            string input = Console.ReadLine();

            while (input != "Clone them!")
            {

                int[] currentNumbers = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                dnaSample++;
                int dnaLenght = 1;
                int startIndex = 0;
                int dnaMaxLenght = 0;
                int sum = 0;
                


                for (int i = 0; i < currentNumbers.Length - 1; i++)
                {
                    if (currentNumbers[i] == 1 && currentNumbers[i + 1] == 1)
                    {
                        dnaLenght++;
                    }
                    else
                    {
                        dnaLenght = 1;
                    }

                    if (dnaMaxLenght < dnaLenght)
                    {
                        dnaMaxLenght = dnaLenght;
                        startIndex = i;
                    }
                    sum += currentNumbers[i];
                }
                sum += currentNumbers[currentNumbers.Length - 1];

                if (bestDnaLenght < dnaMaxLenght)
                {
                    bestDnaLenght = dnaMaxLenght;
                    bestStart = startIndex;
                    bestSum = sum;
                    bestDnaSample = dnaSample;
                    dnaSequence = currentNumbers.ToArray();
                }

                else if (bestDnaLenght == dnaMaxLenght)
                {
                    if (startIndex < bestStart)
                    {
                        bestDnaLenght = dnaMaxLenght;
                        bestStart = startIndex;
                        bestSum = sum;
                        bestDnaSample = dnaSample;
                        dnaSequence = currentNumbers.ToArray();
                    }
                    else if (startIndex == bestStart)
                    {
                        if (sum > bestSum)
                        {
                            bestDnaLenght = dnaMaxLenght;
                            bestStart = startIndex;
                            bestSum = sum;
                            bestDnaSample = dnaSample;
                            dnaSequence = currentNumbers.ToArray();
                        }
                    }
                }


                input = Console.ReadLine();

            }
            Console.WriteLine($"Best DNA sample {bestDnaSample} with sum: {bestSum}.");
            Console.WriteLine(string.Join(' ', dnaSequence));
            
        }
    }
}
