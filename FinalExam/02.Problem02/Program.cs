using System;
using System.Text.RegularExpressions;

namespace _02.Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(\|){1}(?<bossName>[A-Z]{4,})\1\:{1}\#{1}(?<title>[A-Za-z]+ {1}[A-Za-z]+)\#{1}");
            
           

            int inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                string input = Console.ReadLine();
                Match isMatch = Regex.Match(input, pattern.ToString());

                if (isMatch.Success)
                {
                    Console.WriteLine($"{isMatch.Groups["bossName"].Value}, The {isMatch.Groups["title"].Value}");
                    Console.WriteLine($">> Strength: {isMatch.Groups["bossName"].Value.Length}");
                    Console.WriteLine($">> Armor: {isMatch.Groups["title"].Value.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
