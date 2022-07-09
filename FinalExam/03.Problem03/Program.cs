using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem03
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            List<Person> personsInfo = new List<Person>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] cmndArg = input
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = cmndArg[0];

                if (command == "Add")
                {
                    string name = cmndArg[1];
                    int sent = int.Parse(cmndArg[2]);
                    int recieved = int.Parse(cmndArg[3]);
                    int sum = sent + recieved;
                    Person currentPerson = new Person(name, sum);
                    if (!personsInfo.Contains(currentPerson))
                    {
                        personsInfo.Add(currentPerson);
                    }
                    else
                    {
                        continue;
                    }
                }

                else if (command == "Message")
                {
                    string sender = cmndArg[1];
                    string reciever = cmndArg[2];
                    Person currSender = personsInfo.Find(x => x.Name.Equals(sender));
                    Person currReciever = personsInfo.Find(x => x.Name.Equals(reciever));
                    if (currSender != null && currReciever != null)
                    {
                        currSender.Sum++;
                        currReciever.Sum++;
                        if (currSender.Sum >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            personsInfo.Remove(currSender);
                        }
                        if (currReciever.Sum >= capacity)
                        {
                            Console.WriteLine($"{reciever} reached the capacity!");
                            personsInfo.Remove(currReciever);
                        }
                    }
                }

                else if (command == "Empty")
                {
                    string username = cmndArg[1];
                    
                    
                    if (username == "All")
                    {
                        personsInfo.Clear();
                    }
                    else
                    {
                        Person currPerson = personsInfo.Find(x => x.Name.Equals(username));
                        if (currPerson != null)
                        {
                            
                            personsInfo.Remove(currPerson);

                        }
                    }
                    
                }
            }

            Console.WriteLine($"Users count: {personsInfo.Count}");
            foreach (Person pers in personsInfo)
            {
                string name = pers.Name;
                int result = pers.Sum;
                Console.WriteLine($"{name} - {result}");
            }
        }
    }
    class Person
    {
        public Person(string name, int sum)
        {
            this.Name = name;
            this.Sum = sum;
            
        }
        public string Name { get; set; }
        public int Sum { get; set; }
        
    }
}
