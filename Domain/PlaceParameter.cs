using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PlaceParameter : IParameter
    {
        public Direction Direction { get; set; }
        public int ParametersCount => 3;
        public int X { get; set; }
        public int Y { get; set; }
    }
}