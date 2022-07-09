using System;
using System.Linq;

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] temporary = new int[numbers.Length];

            for (int i = 1; i <= rotations; i++)
            {
                int firstNumber = numbers[0];
                for (int j = 1; j < numbers.Length; j++)
                {
                    temporary[j - 1] = numbers[j];
                }
                temporary[temporary.Length - 1] = firstNumber;
                numbers = temporary;
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
