using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public void DriveEmpty(double distance)
        {
            if ((distance * this.FuelConsumptionPerKm) <= this.FuelQuantity)
            {
                this.FuelQuantity -= this.FuelConsumptionPerKm * distance;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public override void Drive(double distance)
        {
            if ((distance * (this.FuelConsumptionPerKm + 1.4)) <= this.FuelQuantity)
            {
                this.FuelQuantity -= (this.FuelConsumptionPerKm + 1.4) * distance;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public override string ToString()
        {
            return $"Bus: {this.FuelQuantity:f2}";
        }
    }
}
