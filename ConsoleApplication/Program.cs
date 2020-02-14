using Core.Parser;
using Core.Robot;
using Core.Simulator;
using Core.Tabletop;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IInputParser, CommandParser>();
            serviceCollection.AddScoped<IParameterParser, PlaceParameterParser>();
            serviceCollection.AddScoped<IRobot, ToyRobot>();
            serviceCollection.AddScoped<ISimulator, ToyRobotSimulator>();
            serviceCollection.AddScoped<ITabletop>(p => new ToyTabletop(5, 5));

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var simulator = serviceProvider.GetService<ISimulator>();

            while (true)
            {
                Console.WriteLine("Enter command: (X = quit)");
                var input = Console.ReadLine();

                if (input.ToUpper().Equals("X"))
                    break;

                simulator.Do(input);
                Console.WriteLine();
            }
        }
    }
}