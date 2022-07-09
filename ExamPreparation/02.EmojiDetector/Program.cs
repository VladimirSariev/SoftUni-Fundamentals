using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(:{2}|\*{2})(?<name>[A-Z]{1}[a-z]{2,})\1");
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern.ToString());
            BigInteger multiply = new BigInteger();
            multiply = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string temp = input[i].ToString();
                    int currNumber = int.Parse(temp);
                    multiply *= currNumber;
                }
            }
            Console.WriteLine($"Cool threshold: {multiply}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (Match item in matches)
            {
                string currentWord = item.Groups["name"].Value;
                int sum = 0;
                for (int i = 0; i < currentWord.Length; i++)
                {
                    int ascii = (int)currentWord[i];
                    sum += ascii;
                }
                if (sum > multiply)
                {
                    Console.WriteLine($"{item.Groups[1].Value}{currentWord}{item.Groups[1].Value}");
                }
                    
            }
        }
    }

}
