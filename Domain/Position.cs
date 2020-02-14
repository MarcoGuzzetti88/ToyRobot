using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Position : ICloneable
    {
        public Position()
        {
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public object Clone()
        {
            return new Position
            {
                X = X,
                Y = Y
            };
        }
    }
}