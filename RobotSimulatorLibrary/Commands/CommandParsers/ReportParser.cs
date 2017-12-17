using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Commands.CommandParsers
{
    public class ReportParser:BaseParser
    {
        public ReportParser(string commandName,ICommandParser commandParser) : base(commandName,commandParser) { }
        public override (ICommand command, bool found) GetCommand(string wordCommand, string parameters)
        {
            return wordCommand.Equals(CommandName, StringComparison.OrdinalIgnoreCase)
                ? (RegistrationService.Container.ResolveKeyed<ICommand>(wordCommand.Trim().ToUpper()), true)
                :(null,false);
        }
    }
}
