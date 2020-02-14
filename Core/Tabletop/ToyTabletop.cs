using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Tabletop
{
    public class ToyTabletop : ITabletop
    {
        public ToyTabletop(int rows, int cols)
        {
            if (rows <= 1)
                throw new ArgumentException("Cannot build a tabletop with negative rows");

            if (cols <= 1)
                throw new ArgumentException("Cannot build a tabletop with negative columns");

            Rows = rows;
            Cols = cols;
        }

        public int Cols { get; private set; }
        public int Rows { get; private set; }

        public bool IsValidPosition(int x, int y)
        {
            return x <= Rows && y <= Cols && x >= 0 && y >= 0;
        }
    }
}