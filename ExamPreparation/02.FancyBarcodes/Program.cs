using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"\@\#+[A-Z][A-Za-z\d]{4,}[A-Z]\@\#+");
            int rotations = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < rotations; i++)
            {
                string input = Console.ReadLine();
                StringBuilder output = new StringBuilder();
                if (pattern.IsMatch(input))
                {
                    
                    for (int y = 0; y < input.Length; y++)
                    {
                        if (Char.IsDigit(input[y]))
                        {
                            output.Append(input[y]);
                        }
                    }

                    if (output.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {output.ToString()}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
