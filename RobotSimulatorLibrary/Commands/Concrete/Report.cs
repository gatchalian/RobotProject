using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Commands.Concrete
{
    public class Report:ICommand
    {
        public Position.Position Position { get; set; }
    }
}
