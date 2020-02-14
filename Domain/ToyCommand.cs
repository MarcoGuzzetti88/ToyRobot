using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ToyCommand
    {
        public Command Command { get; set; }
        public IParameter CommandParameter { get; set; }
    }
}