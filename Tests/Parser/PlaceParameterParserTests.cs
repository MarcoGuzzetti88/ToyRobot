using Core.Parser;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.Parser
{
    public class PlaceParameterParserTests
    {
        [Fact]
        public void PlaceParser_ArgumentMismatch_ThrowsException()
        {
            var parser = new PlaceParameterParser();
            Assert.Throws<ArgumentException>(() => parser.Parse("1,1"));
        }

        [Fact]
        public void PlaceParser_NoValidDirection_ThrowsException()
        {
            var parser = new PlaceParameterParser();
            Assert.Throws<ArgumentException>(() => parser.Parse("1,1,WWW"));
        }

        [Fact]
        public void PlaceParser_NoValidX_ThrowsException()
        {
            var parser = new PlaceParameterParser();
            Assert.Throws<FormatException>(() => parser.Parse("A,1,NORTH"));
        }

        [Fact]
        public void PlaceParser_NoValidY_ThrowsException()
        {
            var parser = new PlaceParameterParser();
            Assert.Throws<FormatException>(() => parser.Parse("1,A,NORTH"));
        }

        [Fact]
        public void PlaceParser_0_0_NORTH_ValidX()
        {
            var parser = new PlaceParameterParser();
            var res = (PlaceParameter)parser.Parse("1,1,NORTH");
            Assert.Equal(1, res.X);
        }

        [Fact]
        public void PlaceParser_0_0_NORTH_ValidY()
        {
            var parser = new PlaceParameterParser();
            var res = (PlaceParameter)parser.Parse("1,1,NORTH");
            Assert.Equal(1, res.Y);
        }

        [Fact]
        public void PlaceParser_0_0_NORTH_ValidDirection()
        {
            var parser = new PlaceParameterParser();
            var res = (PlaceParameter)parser.Parse("1,1,NORTH");
            Assert.Equal(Direction.North, res.Direction);
        }
    }
}