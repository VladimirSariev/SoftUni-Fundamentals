using System;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(\|{1}|#{1})(?<name>[A-Za-z \?]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>[\d]+)\1");
            string info = Console.ReadLine();
            MatchCollection matches = Regex.Matches(info, pattern.ToString());
            int calories = 0;
            if (matches.Count == 0)
            {
                Console.WriteLine("You have food to last you for: 0 days!");
                return;
            }
            
            foreach (Match product in matches)
            {
                calories += int.Parse(product.Groups["calories"].Value);
                
            }
            int totalCalories = calories / 2000;
            Console.WriteLine($"You have food to last you for: {totalCalories} days!");
            foreach (Match product in matches)
            {
                Console.WriteLine($"Item: {product.Groups["name"].Value}, Best before: {product.Groups["date"].Value}, Nutrition: {product.Groups["calories"].Value}");
            }

        }
    }


}
