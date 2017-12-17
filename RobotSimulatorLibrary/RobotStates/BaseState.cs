using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.RobotStates
{
    public class BaseState:IState
    {
        protected ICalculator Calculator;
        protected IRobot Robot;
        public BaseState(IRobot robot, ICalculator calculator)
        {
            Calculator = calculator;
            Robot = robot;
        }
        public Position.Position GetReport()
        {
            return Robot.GetReport();
        }

        public void Execute(ICommand command)
        {
            if (command is null)
                throw new ArgumentException(nameof(command));
            var result = Calculator.GetPositionAndState(command);
            if (result.position != null)
            {
                Robot.SetCurrentPosition(result.position);
            }
            if (result.state != null)
            {
                Robot.SetCurrentState(result.state);
            }
        }
    }
}
