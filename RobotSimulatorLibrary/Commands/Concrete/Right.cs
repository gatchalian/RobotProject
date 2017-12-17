using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Commands.Concrete
{
    public class Right : ICommand
    {
        public Position.Position Position { get; set; }
    }
}
