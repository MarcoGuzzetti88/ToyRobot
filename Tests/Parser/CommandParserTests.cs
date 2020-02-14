using Core.Parser;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.Parser
{
    public class CommandParserTests
    {
        [Fact]
        public void ParseCommand_StringEmpty_CommandUnknown()
        {
            var parameterMock = new Mock<IParameterParser>();
            var parser = new CommandParser(new List<IParameterParser> { parameterMock.Object });
            var res = parser.ParseCommand(string.Empty);
            Assert.Equal(Command.Unknown, res.Command);
        }

        [Fact]
        public void ParseCommand_CommandNotFound_CommandUnknown()
        {
            var parameterMock = new Mock<IParameterParser>();
            var parser = new CommandParser(new List<IParameterParser> { parameterMock.Object });
            var res = parser.ParseCommand("TEST");
            Assert.Equal(Command.Unknown, res.Command);
        }

        [Fact]
        public void ParseCommand_CommandFoundRequiredOneParameterNoParameterProvided_CommandUnknown()
        {
            var parameterMock = new Mock<IParameterParser>();
            var parser = new CommandParser(new List<IParameterParser> { parameterMock.Object });
            var res = parser.ParseCommand("PLACE");
            Assert.Equal(Command.Unknown, res.Command);
        }

        [Fact]
        public void ParseCommand_CommandFoundWithParameter_CorrectCommandParse()
        {
            var parameterMock = new Mock<IParameterParser>();
            parameterMock.SetupGet(g => g.Command).Returns(Command.Place);
            parameterMock.Setup(m => m.Parse("1,1,NORTH")).Returns(new PlaceParameter { X = 1, Y = 1, Direction = Direction.North });
            var parser = new CommandParser(new List<IParameterParser> { parameterMock.Object });
            var res = parser.ParseCommand("PLACE 1,1,NORTH");
            Assert.Equal(Command.Place, res.Command);
        }
    }
}