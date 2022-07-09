using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());
            
            List<Car> cars = new List<Car>();
            for (int i = 0; i < rotations; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string carName = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                Car currentCar = new Car(carName, mileage, fuel);
                cars.Add(currentCar);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] splitInput = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = splitInput[0];
                string currCar = splitInput[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(splitInput[2]);
                    int fuel = int.Parse(splitInput[3]);
                    CarInfo(cars, currCar, distance, fuel);
                    
                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(splitInput[2]);
                    Refill(cars,currCar, fuel);
                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse(splitInput[2]);
                    DecreaseTheKilometres(cars, currCar, kilometers);
                }
            }
            
            PrintTheOutput(cars);
        }

        static void CarInfo(List<Car> cars, string currCar, int distance, int fuel)
        {
            int index = 0;
            bool isTrue = false;
            List<Car> carToRemoveInTheList = new List<Car>();
            foreach (Car car in cars)
            {
                if (car.CarName == currCar)
                {
                    if (car.Fuel >= fuel)
                    {
                        car.Fuel -= fuel;
                        car.Mileage += distance;
                        Console.WriteLine($"{car.CarName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        
                    }

                    else
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                        
                    }
                    if (car.Mileage >= 100000)
                    {
                        index = cars.IndexOf(car);
                        isTrue = true;
                        Console.WriteLine($"Time to sell the {car.CarName}!");
                    }
                   
                }
                
            }

            if (isTrue)
            {
                cars.RemoveAt(index);
            }
        }

        static void Refill(List<Car> cars, string currCar, int fuel)
        {

            
            foreach (Car car in cars)
            {

                int oldAmountOfFuel = car.Fuel;
                
                if (car.CarName == currCar)
                {
                    
                    
                    if (car.Fuel + fuel > 75)
                    {
                        int rest = 75 - oldAmountOfFuel;
                        car.Fuel = 75;
                        Console.WriteLine($"{currCar} refueled with {rest} liters");
                        
                       
                        
                    }
                    else
                    {
                        car.Fuel = car.Fuel + fuel;
                        Console.WriteLine($"{currCar} refueled with {fuel} liters");
                       
                    }
                    
                }
            }
            
            
        }
        static void DecreaseTheKilometres(List<Car> cars,string currCar, int kilometres)
        {
            foreach (Car car in cars)
            {
                if (currCar == car.CarName)
                {
                    if (car.Mileage - kilometres >= 10000)
                    {
                        car.Mileage -= kilometres;
                        Console.WriteLine($"{currCar} mileage decreased by {kilometres} kilometers");
                        break;
                    }
                    else
                    {
                        car.Mileage = 10000;
                    }
                }
            }
        }
        static void PrintTheOutput(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.CarName} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
    class Car
    {   
        public Car(string carName, int mileage, int fuel)
        {
            this.CarName = carName;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
        public string CarName { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
