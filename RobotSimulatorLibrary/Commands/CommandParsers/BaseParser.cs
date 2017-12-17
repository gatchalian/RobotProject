using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Commands.CommandParsers
{
    public class BaseParser:ICommandParser
    {
        protected Position.Position Position;
        protected string CommandName;
        protected ICommandParser CommandParser;
        public BaseParser(string commandName,ICommandParser commandParser)
        {
            CommandName = commandName;
            CommandParser = commandParser;
        }


        public virtual (ICommand command, bool found) GetCommand(string wordCommand, string parameters)
        {
            return wordCommand.Equals(CommandName, StringComparison.OrdinalIgnoreCase) 
                ? (RegistrationService.Container.ResolveKeyed<ICommand>(wordCommand.Trim().ToUpper()), true) 
                : CommandParser.GetCommand(wordCommand,parameters);
        }
    }
}
