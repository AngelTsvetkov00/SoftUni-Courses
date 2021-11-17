﻿using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string line = Console.ReadLine();

                string result = this.commandInterpreter.Read(line);

                if(result == null)
                {
                    break;
                }
                
                Console.WriteLine(result);                
            }
        }
    }
}
