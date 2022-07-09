using System;
using System.Linq;

namespace _08.MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int magicNum = int.Parse(Console.ReadLine());


            for (int i = 0; i < array.Length; i++)
            {
                for (int k = i + 1; k < array.Length; k++)
                {
                    if (array[i] + array[k] == magicNum)
                    {
                        Console.WriteLine($"{array[i]} {array[k]}");
                    }
                }
            }
        }
    }
}
