using Core.Utils;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Parser
{
    public class CommandParser : IInputParser
    {
        private const char SEPARATOR = ' ';
        private readonly IEnumerable<IParameterParser> availableParameterParser;

        public CommandParser(IEnumerable<IParameterParser> availableParameterParser)
        {
            this.availableParameterParser = availableParameterParser;
        }

        public ToyCommand ParseCommand(string input)
        {
            var splittedCommand = input.Split(SEPARATOR);

            if (splittedCommand.Length == 0)
                return new ToyCommand { Command = Command.Unknown };

            var commandAvailabes = Enum.GetValues(typeof(Command))
                .Cast<Enum>()
                .Select(e => e.GetAttributeOfType<CommandAttribute>())
                .ToList();

            if (!TryGetCommand(splittedCommand[0], commandAvailabes, out CommandAttribute selectedCommand))
                return new ToyCommand { Command = Command.Unknown };

            if (splittedCommand.Length - 1 != selectedCommand.ParametersAvailable)
                return new ToyCommand { Command = Command.Unknown };

            var enumCommand = EnumHelper.GetValueFromDescription<Command>(selectedCommand.Command);

            IParameter parameter = null;

            if (selectedCommand.ParametersAvailable > 0)
            {
                if (!TryParseParameter(splittedCommand[1], enumCommand, out parameter))
                    return new ToyCommand { Command = Command.Unknown };
            }

            return new ToyCommand { Command = enumCommand, CommandParameter = parameter };
        }

        private bool TryParseParameter(string commandParameterInput, Command currentCommand, out IParameter parameter)
        {
            parameter = null;
            var currentParser = availableParameterParser.FirstOrDefault(i => i.Command == currentCommand);
            if (currentParser is null)
                return false;

            try
            {
                var result = currentParser.Parse(commandParameterInput);
                parameter = result;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool TryGetCommand(string command, List<CommandAttribute> commandAvailabes, out CommandAttribute selectedCommand)
        {
            var commandAttribute = commandAvailabes.FirstOrDefault(i => i.Command == command.ToUpper());

            if (commandAttribute is null)
            {
                selectedCommand = null;
                return false;
            }

            selectedCommand = commandAttribute;

            return true;
        }
    }
}