using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity,fuelConsumption)
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
            this.FuelQuantity += (liters * 0.95);
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
