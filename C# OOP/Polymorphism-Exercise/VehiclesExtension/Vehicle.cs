using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double _fuelQuantity;
        private double _fuelConsumptionPerKm;
        private int _tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumption;
        }

        public int TankCapacity
        {
            get => _tankCapacity;
            protected set => _tankCapacity = value;
        }

        public double FuelQuantity
        { 
            get => _fuelQuantity;
            protected set
            {
                if (value > TankCapacity)
                {
                    _fuelQuantity = 0;
                }
                else
                {
                    _fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumptionPerKm
        {
            get => _fuelConsumptionPerKm;
            protected set => _fuelConsumptionPerKm = value;
        }

        public virtual void Refuel(double liters)
        {
            if(liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQuantity + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }

        public abstract void Drive(double distance);
    }
}
