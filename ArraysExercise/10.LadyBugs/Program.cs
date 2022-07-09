using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugsIndexes = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[] field = new int[fieldSize];

            for (int index = 0; index < fieldSize; index++)

            {
                if (ladybugsIndexes.Contains(index))
                {
                    field[index] = 1;
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArguments = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int initialIndex = int.Parse(commandArguments[0]);
                string direction = commandArguments[1];
                int flyLenght = int.Parse(commandArguments[2]);

                if (initialIndex < 0 || initialIndex >= fieldSize)
                {
                    continue;
                }

                if (field[initialIndex] == 0)
                {
                    continue;
                }

                field[initialIndex] = 0;
                int nextIndex = initialIndex;

                while (true)
                {
                    if (direction == "right")
                    {
                        nextIndex += flyLenght;
                    }
                    else if (direction == "left")
                    {
                        nextIndex -= flyLenght;
                    }

                    if (nextIndex < 0 || nextIndex >= fieldSize)
                    {
                        break;
                    }
                    if (field[nextIndex] == 0)
                    {
                        break;
                    }
                }

                if (nextIndex >= 0 && nextIndex < fieldSize)
                {
                    field[nextIndex] = 1;
                }
            }
            Console.WriteLine(string.Join (' ', field));
            

        }
    }
}



           
           
            



                
            
           


