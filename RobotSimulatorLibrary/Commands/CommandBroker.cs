using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Autofac;
using RobotSimulatorLibrary.Commands.CommandParsers;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Commands
{
    public class CommandBroker
    {
        private ICommandParser _commandParser;

        public void ResetParsers(ICommandParser commandParser)
        {
            _commandParser = commandParser;
        }

    
        private string GetParameters(Match match)
        {
            return match.Groups.Count > 2 
                ? match.Groups[2].Value 
                : string.Empty;
        }

        private string GetWordCommand(Match match)
        {
            return match.Groups[1].Value;
        }
 

        public (ICommand command, bool found) GetCommand(string input)
        {
            var regex = new Regex($"({StringConstants.Place}|{StringConstants.Move}|{StringConstants.Left}|{StringConstants.Right}|{StringConstants.Report})(.*)");
            var result = regex.Match(input.Trim().ToUpper());
            if (!result.Success) return (null, false);
            var wordCommand = GetWordCommand(result);
            var parameters = GetParameters(result);
            return _commandParser.GetCommand(wordCommand, parameters);
        }
    }
}
