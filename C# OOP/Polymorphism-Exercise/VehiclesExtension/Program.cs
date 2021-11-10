using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries); 
            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]),int.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                string vehicle = command[1];
                var parameter = double.Parse(command[2]);
                switch(action)
                {
                    case "Drive":
                        if (vehicle == "Car")
                        {
                            car.Drive(parameter);
                        }
                        if(vehicle == "Truck")
                        {
                            truck.Drive(parameter);
                        }
                        if (vehicle == "Bus")
                        {
                            bus.Drive(parameter);
                        }
                        break;

                    case "Refuel":
                        if (vehicle == "Car")
                        {
                            car.Refuel(parameter);
                        }
                        if (vehicle == "Truck")
                        {
                            truck.Refuel(parameter);
                        }
                        if (vehicle == "Bus")
                        {
                            bus.Refuel(parameter);
                        }
                        break;

                    case "DriveEmpty":
                        bus.DriveEmpty(parameter);
                        break;
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
