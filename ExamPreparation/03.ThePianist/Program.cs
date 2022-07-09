using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotaations = int.Parse(Console.ReadLine());
            List<Pianist> pieces = new List<Pianist>();

            for (int i = 1; i <= rotaations; i++)
            {
                string[] currentPianist = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string piece = currentPianist[0];
                string name = currentPianist[1];
                string key = currentPianist[2];
                Pianist pianistToAdd = new Pianist(piece, name, key);
                pieces.Add(pianistToAdd);
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] cmndArg = input
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = cmndArg[0];
                if (command == "Add")
                {
                    string piece = cmndArg[1];
                    string name = cmndArg[2];
                    string key = cmndArg[3];
                    Pianist currPianist = new Pianist(piece, name, key);
                    if (pieces.Any(x => x.Piece == piece)) 
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                        continue;
                    }
                    else
                    {
                        pieces.Add(currPianist);
                        Console.WriteLine($"{piece} by {name} in {key} added to the collection!");
                    }
                    
                }
                else if (command == "Remove")
                {
                    string pieceToRemove = cmndArg[1];

                    Pianist currPianist = pieces.Find(x => x.Piece == pieceToRemove);
                    if (pieces.Any(x => x.Piece == pieceToRemove))
                    {
                        pieces.Remove(currPianist);
                        Console.WriteLine($"Successfully removed {pieceToRemove}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceToRemove} does not exist in the collection.");
                        continue;
                    }
                }
                else if (command == "ChangeKey")
                {
                    string piece = cmndArg[1];
                    string newKey = cmndArg[2];
                    Pianist currPianist = pieces.Find(x => x.Piece.Equals(piece));
                    if (currPianist == null)
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        continue;
                    }
                    else
                    {
                        int index = pieces.IndexOf(currPianist);
                        currPianist.Key = newKey;
                        pieces.Remove(currPianist);
                        pieces.Insert(index, currPianist);

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        
                        
                    }
                }
            }

            foreach (Pianist pianist in pieces)
            {
                Console.WriteLine($"{pianist.Piece} -> Composer: {pianist.Name}, Key: {pianist.Key}");
            }
        }
    }
    class Pianist
    {
        public Pianist(string piece, string name, string key)
        {
            this.Piece = piece;
            this.Name = name;
            this.Key = key;
        }
        public string Piece { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
    }
}
