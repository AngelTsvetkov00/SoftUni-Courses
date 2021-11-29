﻿namespace SpaceStation
{
    using Core;
    using Core.Contracts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}