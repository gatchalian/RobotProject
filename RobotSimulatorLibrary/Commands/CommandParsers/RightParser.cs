using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Commands.CommandParsers
{
    public class RightParser:BaseParser
    {
        public RightParser(string commandName,ICommandParser commandParser) : base(commandName,commandParser) { }
    }
}
