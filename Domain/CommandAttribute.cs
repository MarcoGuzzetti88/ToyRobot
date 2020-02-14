using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CommandAttribute : Attribute
    {
        public CommandAttribute(string command, int parametersAvailable = 0)
        {
            Command = command.ToUpper();
            ParametersAvailable = parametersAvailable;
        }

        public string Command { get; }
        public int ParametersAvailable { get; }
    }
}