using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double _fuelQuantity;
        private double _fuelConsumptionPerKm;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumption;
        }

        public double FuelQuantity
        { 
            get => _fuelQuantity; 
            protected set => _fuelQuantity = value; 
        }

        public virtual double FuelConsumptionPerKm
        {
            get => _fuelConsumptionPerKm;
            protected set => _fuelConsumptionPerKm = value;
        }
       
        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public abstract void Drive(double distance);
    }
}
