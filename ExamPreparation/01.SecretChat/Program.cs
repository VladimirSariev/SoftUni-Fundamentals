using System;
using System.Linq;
using System.Text;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string chat = Console.ReadLine();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] splitInput = input
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = splitInput[0];

                if (command == "InsertSpace")
                {
                    int insertOnIndex = int.Parse(splitInput[1]);
                    chat = chat.Insert(insertOnIndex, " ");
                    Console.WriteLine(chat);
                }
                else if (command == "Reverse")
                {
                    string textToCheck = splitInput[1];
                    if (chat.Contains(textToCheck))
                    {
                        int startIndex = chat.IndexOf(textToCheck);
                        
                        chat = chat.Remove(startIndex, textToCheck.Length);

                        ReverseString(ref textToCheck);
                        chat += textToCheck;
                        Console.WriteLine(chat);

                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    string letterToChange = splitInput[1];
                    string letterToInsert= splitInput[2];
                    chat = chat.Replace(letterToChange, letterToInsert);
                    Console.WriteLine(chat);
                }
            }

            Console.WriteLine($"You have a new text message: {chat}");
        }

        
        static string ReverseString(ref string textToCheck)
        {
            StringBuilder reversedText = new StringBuilder();
            for (int i = 0; i < textToCheck.Length; i++)
            {
                reversedText.Append(textToCheck[textToCheck.Length - i - 1]);
            }
            return textToCheck = reversedText.ToString();
        }
    }
}
