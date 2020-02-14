using Core.Parser;
using Core.Robot;
using Core.Tabletop;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Simulator
{
    public class ToyRobotSimulator : ISimulator
    {
        private readonly IInputParser parser;
        private readonly IRobot robot;
        private readonly ITabletop tabletop;

        public ToyRobotSimulator(IRobot robot, IInputParser parser, ITabletop tabletop)
        {
            this.robot = robot ?? throw new ArgumentNullException(nameof(robot));
            this.parser = parser ?? throw new ArgumentNullException(nameof(parser));
            this.tabletop = tabletop ?? throw new ArgumentNullException(nameof(tabletop));
        }

        public string Output { get; private set; }

        public bool Do(string input)
        {
            var command = parser.ParseCommand(input);
            if (IsRobotInUnknownState(command))
                return false;

            switch (command.Command)
            {
                case Command.Place:
                    var parameter = (PlaceParameter)command.CommandParameter;
                    if (tabletop.IsValidPosition(parameter.X, parameter.Y))
                        robot.Place(parameter.X, parameter.Y, parameter.Direction);
                    else
                        return false;
                    break;

                case Command.Move:
                    var newPosition = robot.CalculateNextPosition();
                    if (tabletop.IsValidPosition(newPosition.X, newPosition.Y))
                        robot.Place(newPosition.X, newPosition.Y, robot.CurrentDirection);
                    else
                        return false;
                    break;

                case Command.Left:
                    robot.Rotate(Rotation.Left);
                    break;

                case Command.Right:
                    robot.Rotate(Rotation.Right);
                    break;

                case Command.Report:
                    PrintReport();
                    break;
            }
            return true;
        }

        private bool IsRobotInUnknownState(Domain.ToyCommand command)
        {
            return command.Command != Command.Place && robot.Position == null;
        }

        private void PrintReport()
        {
            Output = string.Empty;

            if (robot.Position != null)
                Output = $"Position: ({robot.Position.X},{robot.Position.Y}) - {robot.CurrentDirection}";

            Console.WriteLine(Output);
        }
    }
}