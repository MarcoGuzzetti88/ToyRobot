using Core.Tabletop;
using System;
using Xunit;

namespace Tests.Tabletop
{
    public class TabletopTests
    {
        [Fact]
        public void Ctor_NewTableTopWithRowNumberLessThan1_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ToyTabletop(0, 5));
        }

        [Fact]
        public void Ctor_NewTableTopWithColumnNumberLessThan1_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ToyTabletop(5, 0));
        }

        [Fact]
        public void Tabletop_InitialInputOuterGrid_IsNotValidPosition()
        {
            var tabletop = new ToyTabletop(5, 5);
            var result = tabletop.IsValidPosition(6, 6);
            Assert.False(result);
        }

        [Fact]
        public void Tabletop_InitialInputInGrid_IsValidPosition()
        {
            var tabletop = new ToyTabletop(5, 5);
            var result = tabletop.IsValidPosition(5, 5);
            Assert.True(result);
        }

        [Fact]
        public void Tabletop_NegativeXInitialInput_IsValidPosition()
        {
            var tabletop = new ToyTabletop(5, 5);
            var result = tabletop.IsValidPosition(-1, 5);
            Assert.False(result);
        }

        [Fact]
        public void Tabletop_NegativeYInitialInput_IsValidPosition()
        {
            var tabletop = new ToyTabletop(5, 5);
            var result = tabletop.IsValidPosition(5, -1);
            Assert.False(result);
        }
    }
}