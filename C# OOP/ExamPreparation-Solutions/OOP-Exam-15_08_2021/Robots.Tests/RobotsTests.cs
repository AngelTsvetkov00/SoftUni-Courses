namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        
        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Azis", 1200);
            robotManager = new RobotManager(3);
        }

        [Test]
        public void Ctor_ShouldCreateValidRobot()
        {
            var robot2 = new Robot(robot.Name, robot.MaximumBattery);

            Assert.AreEqual(robot.Name, robot2.Name);
            Assert.AreEqual(robot.MaximumBattery, robot2.MaximumBattery);
        }

        [Test]
        public void RobotName_ShouldReturnName()
        {
            var robot2 = new Robot(robot.Name, robot.MaximumBattery);

            Assert.AreEqual("Azis", robot2.Name);
        }

        [Test]
        public void Capacity_ShouldThrowExceptionWhenCapacityIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-4));
        }

        [Test]
        public void Capacity_ShouldReturnField()
        {
            Assert.AreEqual(3, robotManager.Capacity);
        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            robotManager.Add(robot);
            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void Add_ShouldThrowExceptionIfNameIsTaken()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Azis",5000)));
        }

        [Test]
        public void Add_ShouldThrowExceptionIfCountIsMax()
        {
            robotManager.Add(robot);
            robotManager.Add(new Robot("Petyo",1500));
            robotManager.Add(new Robot("Acho", 1700));

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Azo", 5000)));
        }

        [Test]
        public void Remove_ShouldThrowExceptionIfRobotIsNull()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Poncho"));
        }

        [Test]
        public void Remove_ShouldDecreaseCount()
        {
            robotManager.Add(robot);
            robotManager.Remove(robot.Name);
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void Work_ShouldThrowExceptionIfRobotIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Poncho","Pich",1000));
        }

        [Test]
        public void Work_ShouldThrowExceptionIfBatteryLifeIsBelow()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Azis", "Pich", 2000));
        }

        [Test]
        public void Work_ShouldReduceBattery()
        {
            robotManager.Add(robot);
            robotManager.Work("Azis", "Pich", 900);

            Assert.AreEqual(300, robot.Battery);
        }

        [Test]
        public void Charge_ShouldThrowExceptionIfRobotIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Poncho"));
        }

        [Test]
        public void Charge_ShouldRechargeProperly()
        {
            robotManager.Add(robot);
            robotManager.Work("Azis", "Pich", 900);
            robotManager.Charge("Azis");

            Assert.AreEqual(1200, robot.Battery);
        }
    }
}
