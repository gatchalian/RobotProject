using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Interfaces
{
    public interface ICalculator
    {
        (Position.Position position,IState state,bool isMatched) GetPositionAndState(ICommand command);
        void ProcessReportCommand();

    }
}
