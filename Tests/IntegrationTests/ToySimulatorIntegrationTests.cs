using Core.Parser;
using Core.Robot;
using Core.Simulator;
using Core.Tabletop;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.IntegrationTests
{
    public class ToySimulatorIntegrationTests
    {
        private ISimulator simulator;

        public ToySimulatorIntegrationTests()
        {
            var placeParameterParser = new PlaceParameterParser();
            simulator = new ToyRobotSimulator(new ToyRobot(), new CommandParser(new List<IParameterParser> { placeParameterParser }), new ToyTabletop(5, 5));
        }

        [Fact]
        public void Simulator_PlaceMoveReport()
        {
            simulator.Do("PLACE 0,0,NORTH");
            simulator.Do("MOVE");
            simulator.Do("REPORT");

            Assert.Equal("Position: (0,1) - North", simulator.Output);
        }

        [Fact]
        public void Simulator_PlaceMoveRightMoveReport()
        {
            simulator.Do("PLACE 0,0,NORTH");
            simulator.Do("MOVE");
            simulator.Do("RIGHT");
            simulator.Do("MOVE");
            simulator.Do("REPORT");

            Assert.Equal("Position: (1,1) - East", simulator.Output);
        }

        [Fact]
        public void Simulator_Place22EastMoveMoveLeftMoveReport()
        {
            simulator.Do("PLACE 2,2,EAST");
            simulator.Do("MOVE");
            simulator.Do("MOVE");
            simulator.Do("LEFT");
            simulator.Do("MOVE");
            simulator.Do("REPORT");

            Assert.Equal("Position: (4,3) - North", simulator.Output);
        }
    }
}