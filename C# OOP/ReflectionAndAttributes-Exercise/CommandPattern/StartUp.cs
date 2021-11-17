using System;
using CommandPattern.Core.Contracts;
using CommandPattern.Core;
using CommandPattern.Commands;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main()
        {
            //ICommandFactory commandFactory = new CommandFactory();

            //ICommand command = commandFactory.CreateCommand("Hello");

            //Console.WriteLine(command.Execute(new string[] { "Angel" }));

            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
            ;
        }
    }
}
