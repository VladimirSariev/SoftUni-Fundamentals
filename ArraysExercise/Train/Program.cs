using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] wagons = new int[number];
            

            for (int i = 0; i < wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                
            }
            int sum = wagons.Sum();
            Console.WriteLine(string.Join(' ',wagons));
            Console.WriteLine(sum);

            
        }
    }
}
