using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Commands;

namespace RobotSimulatorLibrary.Interfaces
{
    public interface ICommandCreator
    {
        (ICommand command,bool found) GetCommand(string command);
    }
}
