using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Commands;

namespace RobotSimulatorLibrary.Interfaces
{
    public interface ICommandParser
    {
        (ICommand command, bool found) GetCommand(string wordCommand, string parameters);
    }
}
