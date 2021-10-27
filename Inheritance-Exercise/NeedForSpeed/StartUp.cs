using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle motor1 = new RaceMotorcycle(200, 40.00);
            Car normalCar = new Car(123, 43);
            Console.WriteLine(normalCar.DefaultFuelConsumption);
        }
    }
}
