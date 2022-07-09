using System;
using System.Linq;

namespace _01.Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Abracadabra")
            {
                string[] cmndArg = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = cmndArg[0];
                if (command == "Abjuration")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (command == "Necromancy")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (command == "Illusion")
                {
                    int index = int.Parse(cmndArg[1]);
                    string letter = cmndArg[2];
                    char newLetter = letter[0];
                    

                    if (index >= 0 && index < text.Length)
                    {
                        char oldLetter = text[index];
                        ChangeLetter(ref text, oldLetter, index, newLetter);
                        Console.WriteLine("Done!");
                    }
                    else
                    {
                        Console.WriteLine("The spell was too weak.");
                    }
                }
                else if (command == "Divination")
                {
                    string firstSubstring = cmndArg[1];
                    string secondSubstring = cmndArg[2];

                    if (text.Contains(firstSubstring))
                    {
                        text = text.Replace(firstSubstring, secondSubstring);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "Alteration")
                {
                    string substring = cmndArg[1];
                    if (text.Contains(substring))
                    {
                        int startIndex = text.IndexOf(substring);
                        text = text.Remove(startIndex, substring.Length);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }
            }
        }
        static string ChangeLetter(ref string text, char oldLetter, int index, char newLetter)
        {
            string newString = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
               
                if (index == i)
                {
                    char temp = newLetter;
                    newString += temp;
                }
                else 
                {
                    newString += text[i];
                }
            }
            text = newString;
            return text;
        }
    }
}
