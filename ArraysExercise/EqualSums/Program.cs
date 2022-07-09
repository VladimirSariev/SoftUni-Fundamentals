using System;
using System.Linq;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int  i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int left = 0; left < i; left++)
                {
                    leftSum += numbers[left];
                }
                for (int right = i + 1; right < numbers.Length; right++)
                {
                    rightSum += numbers[right];
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");


          

            

            
        }

    }
}
