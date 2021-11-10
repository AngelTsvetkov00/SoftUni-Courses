using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumptionPerKm
        {
            get => base.FuelConsumptionPerKm;
            protected set => base.FuelConsumptionPerKm = value + 1.6;
        }

        public override void Drive(double distance)
        {
            if ((distance * this.FuelConsumptionPerKm) <= this.FuelQuantity)
            {
                this.FuelQuantity -= this.FuelConsumptionPerKm * distance;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQuantity + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += (liters * 0.95);
            }
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
