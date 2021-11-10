using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries); 
            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                string vehicle = command[1];
                
                switch(action)
                {
                    case "Drive":
                        var distance = double.Parse(command[2]);
                        if (vehicle == "Car")
                        {
                            car.Drive(distance);
                        }
                        if(vehicle == "Truck")
                        {
                            truck.Drive(distance);
                        }
                        break;

                    case "Refuel":
                        var liters = double.Parse(command[2]);
                        if (vehicle == "Car")
                        {
                            car.Refuel(liters);
                        }
                        if (vehicle == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        break;
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
