using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Commands.Concrete;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Calculators.Visitors
{
    public class ReportVisitor:BasePositionCalculator
    {
        public ReportVisitor(IRobot robot,ICalculator calculator) : base(robot,calculator)
        {
        }

        public override (Position.Position position, IState state, bool isMatched) GetPositionAndState(ICommand command)
        {
            if (command.GetType().Name != nameof(Report)) return (null, null, false);
            ProcessReportCommand();
            IsCommandMatched = true;
            return (null, null,false);
        }

    }
}
