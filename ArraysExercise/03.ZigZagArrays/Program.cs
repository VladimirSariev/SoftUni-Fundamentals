using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());
            int[] array1 = new int[rotations];
            int[] array2 = new int[rotations];
            

            for (int i = 0; i < rotations; i++)
            {
                int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    array1[i] = array[0];
                    array2[i] = array[1];
                }
                else
                {
                    array1[i] = array[1];
                    array2[i] = array[0];
                }
            }
            Console.WriteLine(string.Join(' ', array1));
            Console.WriteLine(string.Join(' ', array2));
        }
    }
}
