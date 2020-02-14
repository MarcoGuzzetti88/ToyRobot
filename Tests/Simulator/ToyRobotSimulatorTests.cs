using Core.Parser;
using Core.Robot;
using Core.Simulator;
using Core.Tabletop;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.Simulator
{
    public class ToyRobotSimulatorTests
    {
        private readonly Mock<IRobot> mockRobot;
        private readonly Mock<IInputParser> mockParser;
        private readonly Mock<ITabletop> mockTabletop;

        public ToyRobotSimulatorTests()
        {
            mockRobot = new Mock<IRobot>();
            mockParser = new Mock<IInputParser>();
            mockTabletop = new Mock<ITabletop>();
        }

        [Fact]
        public void Ctor_RobotIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new ToyRobotSimulator(null, mockParser.Object, mockTabletop.Object));
        }

        [Fact]
        public void Ctor_ParserIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new ToyRobotSimulator(mockRobot.Object, null, mockTabletop.Object));
        }

        [Fact]
        public void Ctor_TabletopIsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new ToyRobotSimulator(mockRobot.Object, mockParser.Object, null));
        }

        [Fact]
        public void Do_UnknownState_CommandIgnored()
        {
            var robotSimulator = new ToyRobotSimulator(mockRobot.Object, mockParser.Object, mockTabletop.Object);
            mockParser.Setup(m => m.ParseCommand("REPORT")).Returns(new ToyCommand { Command = Command.Report });
            var result = robotSimulator.Do("REPORT");
            Assert.False(result);
        }

        [Fact]
        public void Do_PlaceCommand_InvalidPlace_CommandIgnored()
        {
            var robotSimulator = new ToyRobotSimulator(mockRobot.Object, mockParser.Object, mockTabletop.Object);
            mockParser.Setup(m => m.ParseCommand("PLACE 7,5,N")).Returns(new Domain.ToyCommand { Command = Domain.Command.Place, CommandParameter = new PlaceParameter { Direction = Direction.North, X = 7, Y = 7 } });
            mockTabletop.Setup(m => m.IsValidPosition(7, 5)).Returns(false);
            var result = robotSimulator.Do("PLACE 7,5,N");
            Assert.False(result);
        }

        [Fact]
        public void Do_MoveCommand_InvalidPlace_CommandIgnored()
        {
            var robotSimulator = new ToyRobotSimulator(mockRobot.Object, mockParser.Object, mockTabletop.Object);
            mockParser.Setup(m => m.ParseCommand("MOVE")).Returns(new ToyCommand { Command = Command.Move });
            mockRobot.SetupGet(g => g.Position).Returns(new Position { X = 5, Y = 5 });
            mockRobot.Setup(m => m.CalculateNextPosition()).Returns(new Position { X = 5, Y = 6 });
            mockTabletop.Setup(m => m.IsValidPosition(5, 6)).Returns(false);
            var result = robotSimulator.Do("MOVE");
            Assert.False(result);
        }
    }
}