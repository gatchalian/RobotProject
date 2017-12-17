using System;
using RobotSimulatorLibrary.Calculators.Visitors;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Calculators
{
    public class PositionCalculatorVisitor:BasePositionCalculator
    {

        private readonly ICalculator _calculator;

        public PositionCalculatorVisitor(IRobot robot,ICalculator calculator):base(robot,calculator)
        {
            _calculator = calculator;
        }


        public override (Position.Position position, IState state, bool isMatched) GetPositionAndState(ICommand command)
        {
            if (command is null)
                throw new ArgumentException(nameof(command));
            return _calculator.GetPositionAndState(command);
        }
    }
}
