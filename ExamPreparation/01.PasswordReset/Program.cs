using System;
using System.Text;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            
            string input = string.Empty;
           
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] inputArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];
                if (command == "TakeOdd")
                {
                    StringBuilder output = new StringBuilder();
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            output.Append(text[i]);
                        }

                    }
                    text = output.ToString();
                    
                }

                else if (command == "Cut")
                {
                    int startIndex = int.Parse(inputArgs[1]);
                    int lettersToRemove = int.Parse(inputArgs[2]);
                    text = text.Remove(startIndex, lettersToRemove);
                }

                else if (command == "Substitute")
                {
                    string charContains = inputArgs[1];
                    string charToReplace = inputArgs[2];
                    if (text.Contains(charContains))
                    {
                       text = text.Replace(charContains, charToReplace);
                        
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }
                    
                }
                Console.WriteLine(text);

            }

            Console.WriteLine($"Your password is: {text}");
        }
    }
}
