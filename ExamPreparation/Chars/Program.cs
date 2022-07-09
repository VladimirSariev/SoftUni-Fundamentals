using System;

namespace Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 97; i <= 99; i++)
            {
                for (int y = 97; y <= 99; y++)
                {
                    for (int x = 97; x <= 99; x++)
                    {
                        Console.WriteLine($"{(char)i}{(char)y}");
                    }
                }
            }
        }
    }
}
