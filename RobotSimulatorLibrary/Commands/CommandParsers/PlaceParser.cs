using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using Autofac;
using Autofac.Core;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.Position;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Commands.CommandParsers
{

   public class PlaceParser:BaseParser
    {
        public PlaceParser(string commandName,ICommandParser commandParser):base(commandName,commandParser) { }

        public override (ICommand command, bool found) GetCommand(string wordCommand, string parameters)
        {
            return !wordCommand.Equals(CommandName, StringComparison.OrdinalIgnoreCase) 
                ? CommandParser.GetCommand(wordCommand, parameters) 
                : GetCommandWithParameter(wordCommand, parameters);
        }

        private (ICommand command,bool found) GetCommandWithParameter(string wordCommand,string parameters)
        {
            if (!IsParameterValid(parameters))
                return CommandParser.GetCommand(wordCommand,parameters);
            var command = RegistrationService.Container.ResolveKeyed<ICommand>(wordCommand.Trim().ToUpper());
            command.Position = Position;
            return (command, true);
        }

        private void SetPosition(Match match)
        {
            if (!match.Success) return; 

            var x= int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);
            var f =(Direction) Enum.Parse(typeof(Direction), match.Groups[3].Value,true);
            Position =new Position.Position(new Location(x,y),f);
        }

        private bool IsParameterValid(string parameters)
        {
            var regex = new Regex(@"(\d)[,\s]*(\d)[,\s]*(NORTH|EAST|SOUTH|WEST)");
            var match = regex.Match(parameters.Trim());
            SetPosition(match);
            return match.Success;
        }
    }
}
