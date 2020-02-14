using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Parser
{
    public interface IInputParser
    {
        ToyCommand ParseCommand(string input);
    }
}