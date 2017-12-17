using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Calculators.Visitors
{
    public abstract class BasePositionCalculator:ICalculator
    {
        protected bool IsCommandMatched = false;
        protected ICalculator Calculator;
        protected IRobot Robot;

        protected BasePositionCalculator(IRobot robot,ICalculator calculator)
        {
            Calculator = calculator;
            Robot = robot;
        }

        public abstract (Position.Position position, IState state,bool isMatched) GetPositionAndState(ICommand command);

        public  void ProcessReportCommand()
        {
            Robot.GetReport();
        }
    }
}
