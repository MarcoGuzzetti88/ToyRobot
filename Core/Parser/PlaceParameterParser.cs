using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Parser
{
    public class PlaceParameterParser : IParameterParser
    {
        private const char SEPARATOR = ',';

        public Command Command => Command.Place;

        public IParameter Parse(string input)
        {
            var returnParameter = new PlaceParameter { };
            var splittedParameters = input.Split(SEPARATOR);

            if (returnParameter.ParametersCount != splittedParameters.Length)
                throw new ArgumentException($"Parameters count mismatch: {returnParameter.ParametersCount} vs {splittedParameters.Length}");

            var x = Convert.ToInt32(splittedParameters[0]);
            var y = Convert.ToInt32(splittedParameters[1]);

            if (!Enum.TryParse(splittedParameters[splittedParameters.Length - 1], true, out Direction direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

            returnParameter.X = x;
            returnParameter.Y = y;
            returnParameter.Direction = direction;

            return returnParameter;
        }
    }
}