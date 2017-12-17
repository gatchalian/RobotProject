using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Commands.Concrete
{
    public class Move:ICommand
    {
        public Position.Position Position { get; set; }
    }
}
