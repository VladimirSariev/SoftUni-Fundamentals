using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] commandArg = input
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandArg[0];
                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(commandArg[1]);
                    string temp = encryptedMessage.Substring(0, numberOfLetters);
                    encryptedMessage = encryptedMessage.Remove(0, temp.Length);
                    encryptedMessage += temp;
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(commandArg[1]);
                    string value = commandArg[2];
                    
                        encryptedMessage = encryptedMessage.Insert(index, value);
                    
                    
                }
                else if (command == "ChangeAll")
                {
                    string substr = commandArg[1];
                    string replace = commandArg[2];
                    encryptedMessage = encryptedMessage.Replace(substr, replace);
                    
                    
                }
                    input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage.ToString()}");
        }
    }
}
