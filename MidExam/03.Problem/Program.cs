using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine()
                 .Split('&', StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] splitInput = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = splitInput[0];

                switch (command)
                {
                    case "Add Book":
                    string currentBook = splitInput[1];

                        if (books.Contains(currentBook))
                        {
                            continue;
                        }
                        books.Insert(0, currentBook);
                        break;

                    case "Take Book":
                        string findTheBook = splitInput[1];
                        if (books.Contains(findTheBook))
                        {
                            books.Remove(findTheBook);
                        }
                        break;

                    case "Swap Books":

                        string firstBook = splitInput[1];
                        string secondBook = splitInput[2];
                        if (books.Contains(firstBook) && books.Contains(secondBook))
                        {
                            int firstIndex = books.IndexOf(firstBook);
                            int secondIndex = books.IndexOf(secondBook);

                            books.RemoveAt(firstIndex);
                            books.Insert(firstIndex, secondBook);
                            books.RemoveAt(secondIndex);
                            books.Insert(secondIndex, firstBook);
                        }
                        break;

                    case "Insert Book":
                        string bookToAdd = splitInput[1];
                        if (books.Contains(bookToAdd))
                        {
                            continue;
                        }
                        books.Add(bookToAdd);
                        break;

                    case "Check Book":
                        int index = int.Parse(splitInput[1]);
                        if (index >= 0 && index < books.Count)
                        {
                            Console.WriteLine($"{books[index]}");
                        }

                        break;
                         
                }

            }
            Console.WriteLine(string.Join(", ", books));
        }
    }
}
