
using CarRacing.Models.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, 65, 7.5)
        {
        }

        public override void Drive()
        {
            base.Drive();
            int expectedHorsePower = (int)Math.Round(((this.HorsePower) - (this.HorsePower * 0.03)));
            this.HorsePower = expectedHorsePower;
        }
    }
}
