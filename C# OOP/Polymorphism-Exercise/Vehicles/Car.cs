using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity,fuelConsumption)
        {
        }

        public override double FuelConsumptionPerKm
        { 
            get => base.FuelConsumptionPerKm;
            protected set => base.FuelConsumptionPerKm = value + 0.9; 
        }

        public override void Drive(double distance)
        {
            if ((distance * this.FuelConsumptionPerKm) <= this.FuelQuantity)
            {
                this.FuelQuantity -= this.FuelConsumptionPerKm * distance;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
