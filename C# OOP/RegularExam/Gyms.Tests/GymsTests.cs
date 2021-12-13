using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Athlete athlete;
        private Gym gym;
        
        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete(".");
            gym = new Gym(".", 1);
        }

        [Test]
        public void GymName()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 1));
        }

        [Test]
        public void GymName1()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 1));
        }

        [Test]
        public void GymCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Gym(".", -1));
        }

        [Test]
        public void GymCount()
        {
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void GymFullCapacity()
        {
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("joro")));
        }

        [Test]
        public void GymRemoveAthlete()
        {
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("a"));
        }

        [Test]
        public void GymRemoveAthlete2()
        {
            gym.AddAthlete(athlete);
            gym.RemoveAthlete(".");

            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void GymInjureAthlete()
        {
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("a"));
        }

        [Test]
        public void GymInjureAthleteWorks()
        {
            gym.AddAthlete(athlete);
            gym.InjureAthlete(".");
            Assert.AreEqual(true,athlete.IsInjured);
        }

        [Test]
        public void GymInjureAthleteReturns()
        {
            gym.AddAthlete(athlete);

            Assert.AreEqual(athlete, gym.InjureAthlete("."));
        }

        [Test]
        public void Report()
        {
            gym.AddAthlete(athlete);

            var s = gym.Report();

            Assert.AreEqual(s, $"Active athletes at .: .");
        }
    }
}
