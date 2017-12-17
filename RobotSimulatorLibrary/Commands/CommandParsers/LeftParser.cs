using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Commands.CommandParsers
{
    public class LeftParser:BaseParser
    {
        public LeftParser(string commandName,ICommandParser commandParser) : base(commandName,commandParser) { }
    }
}
