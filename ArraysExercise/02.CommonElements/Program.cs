using System;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] array2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


            foreach (var item2 in array2)
            {
                foreach (var item1 in array1)
                {
                    if (item2 == item1)
                    {
                        Console.Write(item2 + " ");
                    }
                }
            }
        }
    }
}
