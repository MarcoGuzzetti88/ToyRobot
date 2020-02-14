using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Parser
{
    public interface IParameterParser
    {
        Command Command { get; }

        IParameter Parse(string input);
    }
}