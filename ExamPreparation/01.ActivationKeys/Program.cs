using System;
using System.Linq;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] cmndArg = input
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = cmndArg[0];
                if (command == "Contains")
                {
                    string substring = cmndArg[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }

                else if (command == "Flip")
                {
                    string upperOrLower = cmndArg[1];
                    int startIndex = int.Parse(cmndArg[2]);
                    int endIndex = int.Parse(cmndArg[3]);
                    if (upperOrLower == "Upper")
                    {
                        string oldString = activationKey.Substring(startIndex, endIndex - startIndex);
                        string substr = activationKey.Substring(startIndex, endIndex - startIndex).ToUpper();
                        activationKey = activationKey.Replace(oldString, substr);
                        
                    }
                    else if (upperOrLower == "Lower")
                    {
                        string oldString = activationKey.Substring(startIndex, endIndex - startIndex);
                        string substr = activationKey.Substring(startIndex, endIndex - startIndex).ToLower();
                        activationKey = activationKey.Replace(oldString, substr);
                    }
                    Console.WriteLine(activationKey);
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(cmndArg[1]);
                    int endIndex = int.Parse(cmndArg[2]);
                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
