using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());

            int students = int.Parse(Console.ReadLine());
            decimal flourPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal apron = decimal.Parse(Console.ReadLine());

            decimal extraAprons = Math.Ceiling(students * 1.2m);
            decimal apronsFinalPrice = apron * extraAprons;
            flourPrice = flourPrice * (students - (students / 5));
            decimal eggsFinalPrice = (eggPrice * 10) * students;

            decimal totalPrice = apronsFinalPrice + flourPrice + eggsFinalPrice;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
            else
            {
                totalPrice -= budget;
                Console.WriteLine($"{totalPrice:f2}$ more needed.");
            }


        }
    }
}
