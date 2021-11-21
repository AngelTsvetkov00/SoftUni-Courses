using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Make","Model",5,100);
        }

        [Test]
        //AllInvalid
        [TestCase("", "", -1, 0)]
        [TestCase(null, null, -1, 0)]
        [TestCase("", null, -1, 0)]
        [TestCase(null, "", -1, 0)]
        //Invalid FuelCapacity
        [TestCase("Make", "Model", 5, 0)]
        //Invalid FuelConsumption
        [TestCase("Make", "Model", -1, 10)]
        //Invalid Make
        [TestCase("", "Model", 5, 100)]
        [TestCase(null, "Model", 5, 100)]
        //Invalid Model
        [TestCase("Make", "", 5, 100)]
        [TestCase("Make", null, 5, 100)]
        //Combination(8, 4) = 70 invalid cases possible;
        public void Ctor_ShouldThrowExceptionWhenDataIsInvalid(string make,string model,double fuelConsumption,double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_ShouldAcceptValidData()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 5;
            double fuelCapacity = 100;

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }


        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Refuel_ShouldThrowExceptionIfDataIsInvalid(double fuelToRefuel)
        {        
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        public void Refuel_ShouldIncrementFuelAmount()
        {
            car.Refuel(65);
            car.Refuel(34);
            var expectedFinalFuel = 99;
            Assert.AreEqual(car.FuelAmount, expectedFinalFuel);
        }

        [Test]
        public void Amount_ShouldNotExceedFuelCapacity()
        {
            car.Refuel(150);
            car.Refuel(300);
            var expectedFinalFuel = car.FuelCapacity;
            Assert.AreEqual(car.FuelAmount, expectedFinalFuel);
        }

        [Test]
        public void Drive_ShouldThrowExceptionIfFuelIsNotEnough()
        {
            double distance = 100;
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        public void Drive_ShouldDecrementFuelAmount()
        {
            car.Refuel(10);
            car.Drive(100);
            var expectedFuelAmountLeft = 5;
            Assert.AreEqual(expectedFuelAmountLeft, car.FuelAmount);
        }
    }
}